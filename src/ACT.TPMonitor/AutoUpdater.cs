using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Advanced_Combat_Tracker;
using Newtonsoft.Json;
using Ionic.Zip;

namespace ACT.TPMonitor
{
    class AutoUpdater
    {
        private static Regex regVersion = new Regex(@"FileVersion: (?<version>\d+\.\d+\.\d+\.\d+)\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static bool isGitHubAPI;
        private static MemoryStream requestData;
        private static byte[] bufferData;

        public static string Owner { get; set; }
        public static string RepositoryName { get; set; }
        public static ActPluginData PluginDate { get; set; }
        public static Version CurrentVersion
        {
            get
            {
                return new Version(regVersion.Match(PluginDate.pluginVersion).Groups["version"].ToString());
            }
        }
        public static bool IsCoverdPreRelease { private get; set; }

        public static void Start()
        {
            string githubAPI = string.Format("https://api.github.com/repos/{0}/{1}/releases", Owner, RepositoryName);
            isGitHubAPI = true;
            Start(githubAPI);
        }

        public static void Start(string url)
        {            
            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(url);
            webreq.UserAgent = Owner;

            IAsyncResult r = (IAsyncResult)webreq.BeginGetResponse(new AsyncCallback(ResponseCallback), webreq);
        }

        private static void ResponseCallback(IAsyncResult ar)
        {
            HttpWebRequest webreq = (HttpWebRequest)ar.AsyncState;

            HttpWebResponse webres = (HttpWebResponse)webreq.EndGetResponse(ar);

            Stream st = webres.GetResponseStream();

            requestData = new System.IO.MemoryStream();
            bufferData = new byte[1024];

            IAsyncResult r = (IAsyncResult)st.BeginRead(bufferData, 0, bufferData.Length, new AsyncCallback(ReadCallback), st);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            Stream st = (Stream)ar.AsyncState;

            int readSize = st.EndRead(ar);

            if (readSize > 0)
            {
                requestData.Write(bufferData, 0, readSize);

                //Console.WriteLine("{0} Bytes", requestData.Length);

                IAsyncResult r = (IAsyncResult)st.BeginRead(bufferData, 0, bufferData.Length, new AsyncCallback(ReadCallback), st);
            }
            else
            {
                byte[] sourceData = requestData.ToArray();
                st.Close();
                requestData.Close();

                if (isGitHubAPI)
                {
                    //GitHub API responsed.
                    string sourceHtml = System.Text.Encoding.UTF8.GetString(sourceData);

                    List<GitHub.Release> releases = JsonConvert.DeserializeObject<List<GitHub.Release>>(sourceHtml);
                    GitHub.Release newVersion = CheckNewAvailable(releases);

                    if (newVersion != null)
                    {
                        var title = "New version available!";
                        var instruction = String.Format("A new version of {0} is available.", RepositoryName);
                        var msg = string.Format("\n\n{0} {1}{2} is now available.\nYou have version {3}.\nApply it now?\n\n:{4}\n -{5}", 
                            RepositoryName, 
                            newVersion.tag_name, 
                            IsCoverdPreRelease && newVersion.prerelease ? "[PreRelease]" : "", 
                            CurrentVersion, 
                            newVersion.name, 
                            newVersion.body
                            );
                        var result = MessageBox.Show(instruction + msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            GetZipFile(newVersion.assets[0].browser_download_url);
                        }
                    }
                    else
                    {
                        if (IsCoverdPreRelease)
                        {
                            var titile = "Update Check";
                            var msg = string.Format("You have version {0} is the latest.", CurrentVersion);
                            MessageBox.Show(msg, titile, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    //zip file download completed.
                    Apply(sourceData);
                }
            }
        }

        private static GitHub.Release CheckNewAvailable(List<GitHub.Release> releses)
        {
            DateTime localFileUpdateTime = PluginDate.pluginFile.LastWriteTime;
#if DEBUG 
            localFileUpdateTime = DateTime.Parse("2014/11/10 1:10:08");
            localFileUpdateTime = localFileUpdateTime.AddDays(-10);
#endif
            localFileUpdateTime = localFileUpdateTime.AddMinutes(30);
            foreach (GitHub.Release r in releses)
            {
                if (r.draft) continue;
                if (r.assets.Count == 0) continue;
                if (!(r.assets[0].content_type.Equals("application/x-zip-compressed") && r.assets[0].state.Equals("uploaded"))) continue;
                if (r.prerelease && !IsCoverdPreRelease) continue;

                DateTime updatedTime = DateTime.Parse(r.assets[0].updated_at);
                if (updatedTime.CompareTo(localFileUpdateTime) == 1)
                {
                    return r;
                }
            }
            return null;
        }

        private static void GetZipFile(string downloadURL)
        {
            isGitHubAPI = false;
            Start(downloadURL);
        }

        private static void Apply(byte[] sourceData)
        {
            using (MemoryStream ms = new MemoryStream(sourceData))
            {
                using (ZipFile zip = ZipFile.Read(ms))
                {
                    zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string zipPath = path;
                    if (PluginDate != null)
                    {
                        path = PluginDate.pluginFile.DirectoryName;
                    }

                    zip.ExtractAll(path);

                    ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, PluginDate.cbEnabled, false);
                    Application.DoEvents();

                    foreach (ZipEntry entry in zip)
                    {
                        string src = Path.Combine(path, entry.FileName);
                        string dest = Path.Combine(path, Path.GetFileName(entry.FileName));
                        if (File.Exists(dest))
                        {
                            File.Delete(dest + "_old");
                            File.Move(dest, dest + "_old");
                            File.Copy(src, dest, true);
                        }
                        zipPath = Path.GetDirectoryName(src);
                    }
                    Directory.Delete(zipPath, true);

                    ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, PluginDate.cbEnabled, true);
                    PluginDate.pluginFile.Refresh();
                }
            }
        }
    }
}
