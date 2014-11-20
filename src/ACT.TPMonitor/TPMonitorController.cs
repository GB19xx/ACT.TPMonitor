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
        public readonly Version SUPPORTED_VERSION = new Version("1.2.2.0");

        public ActPluginData actPlugin { get; private set; }
        public bool IsUnSupportedVerion { get; private set; }
        public string CharFolder { get; set; }

        public bool IsACTVisible { get; set; }
        public bool IsFFXIVPluginStarted { get; set; }
        public bool IsFFXIVProcessStarted { get; set; }
        public bool IsLoggedIn { get; set; }
        public Point ViewLocation { get; set; }

        public Font TPFont { get; set; }
        public Widget PartyListUI { get; set; }

        public bool HideWhenDissolve { get; set; }
        public bool HideWhenEnded { get; set; }
        public bool ShowMyTP { get; set; }
        public bool DisappearsInActive { get; set; }

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

        public SynchronizedCollection<Combatant> PartyMemberInfo { get; private set; }
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
        private Process ffxivProcess = null;
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

            PartyMemberInfo = new SynchronizedCollection<Combatant>();
            for (int i = 0; i < 8; i++)
            {
                PartyMemberInfo.Add(new Combatant());
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

                bool oldACTVisible = IsACTVisible;
                bool oldFFXIVPlugin = IsFFXIVPluginStarted;
                bool oldFFXIVProcess = IsFFXIVProcessStarted;
                bool oldLoggedIn = IsLoggedIn;
                Point oldViewLocation = ViewLocation;
                try
                {

                    IsACTVisible = ActGlobals.oFormActMain.Visible;
                    IsFFXIVPluginStarted = false;
                    if (ActGlobals.oFormActMain.Visible)
                    {
                        IsFFXIVPluginStarted = FFXIVPluginHelper.Instance == null ? false : true;
                    }
                    if (!oldFFXIVPlugin && IsFFXIVPluginStarted)
                    {
                        if (FFXIVPluginHelper.GetVersion.CompareTo(SUPPORTED_VERSION) == -1)
                            IsUnSupportedVerion = true;
                        else
                            IsUnSupportedVerion = false;
                    }

                    ffxivProcess = FFXIVPluginHelper.GetFFXIVProcess;

                    if (ffxivProcess != null)
                    {
                        IsFFXIVProcessStarted = true;
                        Util.FFXIVProcessId = ffxivProcess.MainWindowHandle;

                        Combatant player = FFXIVPluginHelper.GetPlayerData();
                        if (player.Job != 0)
                        {
                            IsLoggedIn = true;

                            if (oldLoggedIn == false)
                            {
                                Util.InitializedAtLogin();

                                switch (Util.GameLanguage)
                                {
                                    case Language.English:
                                        regexDissolve = new Regex(@"(You (dissolve the|leave .+'s) party|The party has been disbanded)\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        regexEnded = new Regex(@".+ has ended\.$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        break;
                                    case Language.German:
                                        regexDissolve = new Regex(@"((Deine|Die) Gruppe wurde aufgelöst|Du bist aus der Gruppe von .+ ausgetreten)\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        regexEnded = new Regex(@"„.+“ wurde beendet\.$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        break;
                                    case Language.French:
                                        regexDissolve = new Regex(@"(L'équipe (est|a été) dissoute|Vous quittez l'équipe de .+)\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        regexEnded = new Regex(@"La mission “.+” commence\.$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        break;
                                    case Language.Japanese:
                                    default:
                                        regexDissolve = new Regex(@"(パーティ(を解散しま|が解散されま)した|のパーティから離脱しました)。", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        regexEnded = new Regex(@"「.+?」の攻略を終了した。$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            IsLoggedIn = false;
                        }
                    }
                    else
                    {
                        IsFFXIVProcessStarted = false;
                        IsLoggedIn = false;

                        // clear
                        for (int i = 0; i < 8; i++)
                        {
                            PartyMemberInfo[i].Job = (int)JOB.Unknown;
                            PartyMemberInfo[i].Name = string.Empty;
                            PartyMemberInfo[i].CurrentTP = 0;
                        }
                        // hide at dissolution.
                        viewer.Hide();
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
                    if (oldACTVisible != IsACTVisible || 
                        oldFFXIVPlugin != IsFFXIVPluginStarted ||
                        oldFFXIVProcess != IsFFXIVProcessStarted ||
                        oldLoggedIn != IsLoggedIn ||
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
                        PartyMemberInfo[i].Job = (int)JOB.Unknown;
                        PartyMemberInfo[i].Name = string.Empty;
                        PartyMemberInfo[i].CurrentTP = 0;
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
                                    PartyMemberInfo[i].Job = (int)JOB.Unknown;
                                    PartyMemberInfo[i].Name = string.Empty;
                                    PartyMemberInfo[i].CurrentTP = 0;
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

                if (ffxivProcess == null)
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
                    if (combatantList == null) continue;

                    for (int i = 0; i < PartyMemberInfo.Count; i++)
                    {
                        if (combatantList.Count == 0)
                        {
                            break;
                        }

                        PartyMemberInfo[0].Name = combatantList[0].Name;
                        PartyMemberInfo[0].CurrentTP = combatantList[0].CurrentTP;

                        foreach (Combatant c in combatantList)
                        {
                            if (PartyMemberInfo[i].Name.Equals(c.Name))
                            {
                                PartyMemberInfo[i].Job = c.Job;
                                PartyMemberInfo[i].Name = c.Name;
                                PartyMemberInfo[i].CurrentHP = c.CurrentHP;
                                PartyMemberInfo[i].MaxHP = c.MaxHP;
                                PartyMemberInfo[i].CurrentMP = c.CurrentMP;
                                PartyMemberInfo[i].MaxMP = c.MaxMP;
                                PartyMemberInfo[i].CurrentTP = c.CurrentTP;
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
