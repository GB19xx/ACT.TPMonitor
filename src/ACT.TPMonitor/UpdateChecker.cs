/* UpdateChecker.cs
 * 
 * Copyright (c) 2014, grindingcoil
 * All rights reserved.
 * 
 * Originally under 3-clause BSD license, https://github.com/grindingcoil/act_timeline/blob/master/LICENSE.txt
 * 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ACT.TPMonitor
{
    public class RemoteVersionInfo
    {
        private string version;
        private string changeSummaryJp; // FIXME: i18n
        private string downloadUrl;
        public string Version { get { return version; } }
        public string ChangeSummaryJp { get { return changeSummaryJp; } }
        public string DownloadUrl { get { return downloadUrl; } }

        RemoteVersionInfo() { }

        public delegate string FetchUrlDelegate(string url);
        static public FetchUrlDelegate FetchUrlImpl = FetchUrlUsingWebRequest;

        static public string FetchUrlUsingWebRequest(string url)
        {
            var client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            return client.DownloadString(url);
        }

        public static RemoteVersionInfo FetchUrl(string url)
        {
            var src = FetchUrlImpl(url);
            return FromXml(src);
        }

        private static string GetNodeText(XmlDocument xml, string nodepath)
        {
            var node = xml.DocumentElement.SelectSingleNode(nodepath);
            if (node == null)
                return "";

            return node.InnerText;
        }

        public static RemoteVersionInfo FromXml(string src)
        {
            var xml = new XmlDocument();
            xml.LoadXml(src);

            var version = GetNodeText(xml, "/versionInfo/version");
            var changeSummaryJp = GetNodeText(xml, "/versionInfo/changeSummary/jp");
            var downloadUrl = GetNodeText(xml, "/versionInfo/downloadUrl");

            return new RemoteVersionInfo { version = version, changeSummaryJp = changeSummaryJp, downloadUrl = downloadUrl };
        }
    }

    public class UpdateChecker
    {
        string localVersion;

        const string DefaultVersionInfoUrl = "https://raw.githubusercontent.com/GB19xx/ACT.TPMonitor/master/version_info.xml";
        string versionInfoUrl;

        public UpdateChecker(string localVersion_, string versionInfoUrl_ = DefaultVersionInfoUrl)
        {
            localVersion = localVersion_;
            versionInfoUrl = versionInfoUrl_;
        }

        public void PerformCheckOnNewThread()
        {
            new Thread(new ThreadStart(PerformCheck)).Start();
        }

        public static int CompareVersionString(string a, string b)
        {
            return new Version(a).CompareTo(new Version(b));
        }

        public void PerformCheck()
        {
            try
            {
                var remoteInfo = RemoteVersionInfo.FetchUrl(versionInfoUrl);
                if (CompareVersionString(remoteInfo.Version, localVersion) > 0)
                {
                    var msg = String.Format("TPMonitorの更新版が公開されています: {0}\nお手元のバージョン: {1}\n主な変更:\n{2}\nダウンロードサイトを開きますか？",
                        remoteInfo.Version, localVersion, remoteInfo.ChangeSummaryJp);
                    var result = MessageBox.Show(msg, "ACT.TPMonitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(remoteInfo.DownloadUrl);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Update check failed:\r\n{0}", ex.Message), "ACT.TPMonitor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
