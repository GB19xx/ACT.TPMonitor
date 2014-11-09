using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Advanced_Combat_Tracker;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ACT.TPMonitor
{
    public class TPMonitorController : IDisposable
    {
        public ActPluginData actPlugin { get; private set; }
        public string CharFolder { get; set; }

        public bool ACTVisible { get; set; }
        public bool FFXIVPluginStatus { get; set; }
        public bool FFXIVProcess { get; set; }
        public bool LoggedIn { get; set; }
        public Point ViewLocation { get; set; }

        public Font TPFont { get; set; }
        public Widget PartyListUI { get; set; }

        public bool HideWhenDissolve { get; set; }
        public bool HideWhenEnded { get; set; }
        public bool ShowMyTP { get; set; }

        public bool IsFixedMode { get; set; }
        public decimal OffsetX { get; set; }
        public decimal OffsetY { get; set; }
        public decimal FixedX { get; set; }
        public decimal FixedY { get; set; }
        public bool IsAllianceStyle { get; set; }
        public decimal AllianceX { get; set; }
        public decimal AllianceY { get; set; }
        public bool IsUserScale { get; set; }
        public float UserScale { get; set; }

        public SynchronizedCollection<PartyMember> PartyMemberInfo { get; private set; }
        public SynchronizedCollection<JOB> HideJob { get; set; }
        public DataTable dtColor { get; set; }

        private Regex regexCmd = new Regex(@"(?<Time>\[.+?\]) .{2}:.{4}:TP ((?<Num>\d):(?<Name>.*)|/(?<Command>.+))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex regexDissolve = new Regex(@"(パーティ(を解散しま|が解散されま)した|のパーティから離脱しました)。", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex regexEnded = new Regex(@"「.+?」の攻略を終了した。$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private ACTTabpageControl actTab;
        private Form viewer;
        private TPViewer normalStyle;
        private AllianceStyleViewer allianceStyle;
        private Thread checkStatus = null;
        private Thread getTP = null;
        private Process _ffxivProcess = null;
        private IntPtr zero = IntPtr.Zero;
        private bool isExited;        

        public TPMonitorController(ACTTabpageControl actTab)
        {
            this.actPlugin = ActGlobals.oFormActMain.PluginGetSelfData(actTab);
            this.actTab = actTab;
            this.actTab.ChangeLocation += new ACTTabpageControl.ChangeLocationEventHandler(this.ChangeLocation);
            this.actTab.ChangeScale += new ACTTabpageControl.ChangeScaleEventHandler(this.ChangeScale);

            HideJob = new SynchronizedCollection<JOB>();

            ActGlobals.oFormActMain.OnLogLineRead += act_OnLogLineRead;

            isExited = false;

            PartyMemberInfo = new SynchronizedCollection<PartyMember>();
            for (int i = 0; i < 8; i++)
            {
                PartyMemberInfo.Add(new PartyMember());
            }

            normalStyle = new TPViewer(this);
            normalStyle.Show();
            normalStyle.Hide();

            allianceStyle = new AllianceStyleViewer(this);
            allianceStyle.Show();
            allianceStyle.Hide();

            if (this.IsAllianceStyle)
                viewer = allianceStyle;
            else
                viewer = normalStyle;
            
            checkStatus = new Thread(new ThreadStart(CheckProcess));
            checkStatus.Name = "Check Status Thread";
            checkStatus.Start();

            getTP = new Thread(new ThreadStart(GetMemberTP));
            getTP.Name = "Get TP Thread";
            getTP.Start();
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= act_OnLogLineRead;

            isExited = true;

            viewer.Hide();

            if (checkStatus.IsAlive && checkStatus.ThreadState == System.Threading.ThreadState.Running)
                checkStatus.Abort();
            if (getTP.IsAlive && getTP.ThreadState == System.Threading.ThreadState.Running)
                getTP.Abort();

            normalStyle.Close();
            normalStyle.Dispose();
            allianceStyle.Close();
            allianceStyle.Dispose();
        }

        private void ChangeLocation(object sender, ACTTabpageControl.ChangeLocationEventArgs e)
        {
            if (viewer.Visible)
            {
                if (viewer.GetType().Name == "TPViewer" && this.IsAllianceStyle)
                {
                    viewer.Hide();
                    viewer = allianceStyle;
                    viewer.Show();
                }
                else if (viewer.GetType().Name == "AllianceStyleViewer" && !this.IsAllianceStyle)
                {
                    viewer.Hide();
                    viewer = normalStyle;
                    viewer.Show();
                }
            }
            viewer.Location = e.Location;
        }

        private void ChangeScale(object sender, ACTTabpageControl.ChangeScaleEventArgs e)
        {
            if (this.IsAllianceStyle)
                allianceStyle.Adjust();
            else
                normalStyle.Adjust(Util.GetPartyListLocation(this.CharFolder, this.IsUserScale ? e.Scale : 0f));
        }

        public event EventHandler ChangedStatus;
        private void CheckProcess()
        {
            while (true)
            {
                if (isExited) break;

                bool oldACTVisible = ACTVisible;
                bool oldFFXIVPlugin = FFXIVPluginStatus;
                bool oldFFXIVProcess = FFXIVProcess;
                bool oldLoggedIn = LoggedIn;
                bool status = false;
                Point oldViewLocation = ViewLocation;
                try
                {

                    ACTVisible = ActGlobals.oFormActMain.Visible;
                    if (ActGlobals.oFormActMain.Visible)
                    {
                        status = false;
                        foreach (ActPluginData plugin in ActGlobals.oFormActMain.ActPlugins)
                        {
                            if (plugin.pluginFile.Name == "FFXIV_ACT_Plugin.dll" && plugin.lblPluginStatus.Text == "FFXIV Plugin Started.")
                            {
                                if (FFXIVPluginHelper.Instance == null)
                                {
                                    FFXIVPluginHelper.Instance = (object)plugin.pluginObj;
                                    FFXIVPluginHelper.Version = new Version(FileVersionInfo.GetVersionInfo(plugin.pluginFile.ToString()).FileVersion);
                                } 
                                
                                status = true;
                                                                
                                break;
                            }
                        }
                        FFXIVPluginStatus = status;

                        _ffxivProcess = FFXIVPluginHelper.GetFFXIVProcess;
                    }
                    else
                    {
                        FFXIVPluginStatus = false;
                    }

                    FFXIVProcess = _ffxivProcess != null ? true : false;
                    Util.FFXIVProcessId = _ffxivProcess.MainWindowHandle;

                    if (_ffxivProcess != null)
                    {
                        Combatant player = FFXIVPluginHelper.GetPlayerData();
                        LoggedIn = player.MaxHP > 0 ? true : false;
                    }
                    else
                    {
                        LoggedIn = false;
                    }

                    ViewLocation = viewer.Location;

                    Thread.Sleep(500);
                }
                catch
                {
                    Thread.Sleep(500);
                }
                finally
                {
                    if (oldACTVisible != ACTVisible || oldFFXIVPlugin != FFXIVPluginStatus ||
                        oldFFXIVProcess != FFXIVProcess || oldLoggedIn != LoggedIn ||
                        oldViewLocation != ViewLocation)
                    {
                        ChangedStatus(this, new EventArgs());
                    }
                }
            }
        }

        private void act_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (!isImport)
            {
                if ((this.HideWhenDissolve && regexDissolve.IsMatch(logInfo.logLine)) ||
                    (this.HideWhenEnded && regexEnded.IsMatch(logInfo.logLine)))
                {
                    // clear
                    for (int i = 0; i < 8; i++)
                    {
                        PartyMemberInfo[i].Job = JOB.Unknown;
                        PartyMemberInfo[i].Name = string.Empty;
                        PartyMemberInfo[i].TP = 0;
                    }
                    // hide at dissolution.
                    viewer.Hide();
                    return;
                }

                Match match = regexCmd.Match(logInfo.logLine);
                if (match.Success)
                {
                    string command = match.Groups["Command"].ToString().ToLower();
                    if (string.IsNullOrEmpty(command))
                    {
                        switch (match.Groups["Num"].ToString())
                        {
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                                int idx = int.Parse(match.Groups["Num"].Value.ToString()) - 1;
                                PartyMemberInfo[idx].Name = match.Groups["Name"].Value.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (command)
                        {
                            case "adjust":
                                this.PartyListUI = Util.GetPartyListLocation(this.CharFolder);
                                if (this.IsAllianceStyle)
                                    allianceStyle.Adjust();
                                else
                                    normalStyle.Adjust();
                                break;
                            case "clear":
                                for (int i = 0; i < 8; i++)
                                {
                                    PartyMemberInfo[i].Job = JOB.Unknown;
                                    PartyMemberInfo[i].Name = string.Empty;
                                    PartyMemberInfo[i].TP = 0;
                                }
                                break;
                            case "hide":
                                viewer.Hide();
                                break;
                            case "show":
                                if (this.IsAllianceStyle)
                                    viewer = allianceStyle;
                                else
                                    viewer = normalStyle;

                                if (!viewer.Visible)
                                {
                                    this.PartyListUI = Util.GetPartyListLocation(this.CharFolder);
                                }
                                if (this.IsAllianceStyle)
                                    allianceStyle.Adjust();
                                else
                                    normalStyle.Adjust();
                                viewer.TopMost = true;
                                viewer.Show();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void GetMemberTP()
        {
            while (true)
            {
                if (isExited) break;

                if (_ffxivProcess == null)
                {
                    Thread.Sleep(3000);
                    continue;
                }

                if (!viewer.Visible || PartyMemberInfo.Count == 0)
                {
                    Thread.Sleep(100);
                    continue;
                }

                try
                {
                    List<Combatant> combatantList = FFXIVPluginHelper.GetCombatantList();
                    for (int i = 0; i < PartyMemberInfo.Count; i++)
                    {
                        if (combatantList.Count == 0)
                        {
                            break;
                        }

                        PartyMemberInfo[0].Name = combatantList[0].Name;
                        PartyMemberInfo[0].TP = combatantList[0].CurrentTP;

                        foreach (Combatant c in combatantList)
                        {
                            if (PartyMemberInfo[i].Name.Equals(c.Name))
                            {
                                PartyMemberInfo[i].Job = (JOB)c.Job;
                                PartyMemberInfo[i].TP = c.CurrentTP;
                                break;
                            }
                        }
                    }

                    OnCurrentTPUpdate();

                }
                finally
                {
                    Thread.Sleep(200);
                }
            }
        }

        public event EventHandler CurrentTPUpdate;
        public void OnCurrentTPUpdate()
        {
            if (CurrentTPUpdate != null)
                CurrentTPUpdate(this, EventArgs.Empty);
        }
    }
}
