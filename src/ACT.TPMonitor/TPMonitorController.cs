using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Advanced_Combat_Tracker;
using System.Text.RegularExpressions;
using System.Threading;
using FFXIV_ACT_Plugin;

namespace ACT.TPMonitor
{
    public class TPMonitorController : IDisposable
    {
        public class PartyMember
        {
            public string Name { get; set; }
            public int TP { get; set; }

            public PartyMember()
            {
                this.Name = "";
                this.TP = 0;
            }
        }

        public string CharFolder { get; set; }

        public bool ACTVisible { get; set; }
        public bool FFXIVPluginStatus { get; set; }
        public bool FFXIVProcess { get; set; }
        public bool LoggedIn { get; set; }

        public Font TPFont { get; set; }
        public Rectangle PartyListUI { get; set; }

        public List<PartyMember> PartyMemberInfo { get; private set; }

        private Regex regex = new Regex(@"(?<Time>\[.+?\]) TP ((?<Num>\d):(?<Name>.*)|/(?<Command>.+))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        TPViewer view;
        Thread checkStatus =null;
        Thread getTP = null;
        private Process _ffxivProcess = null;
        private IntPtr zero = IntPtr.Zero;
        private bool stoped;

        public TPMonitorController()
        {
            ActGlobals.oFormActMain.OnLogLineRead += act_OnLogLineRead;

            stoped = false;

            PartyMemberInfo = new List<PartyMember>();
            for (int i = 0; i < 8; i++)
            {
                PartyMemberInfo.Add(new PartyMember());
            }

            view = new TPViewer(this);
            view.Show();
            view.Hide();

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

            stoped = true;

            if (checkStatus.IsAlive && checkStatus.ThreadState == System.Threading.ThreadState.Running)
                checkStatus.Abort();
            if (getTP.IsAlive && getTP.ThreadState == System.Threading.ThreadState.Running)
                getTP.Abort();

            view.Close();
            view.Dispose();
        }

        public event EventHandler ChangedStatus;
        private void CheckProcess()
        {
            while (true)
            {
                if (stoped) break;

                try
                {
                    bool oldACTVisible = ACTVisible;
                    bool oldFFXIVPlugin = FFXIVPluginStatus;
                    bool oldFFXIVProcess = FFXIVProcess;
                    bool oldLoggedIn = LoggedIn;
                    bool status = false;

                    ACTVisible = ActGlobals.oFormActMain.Visible;
                    if (ActGlobals.oFormActMain.Visible)
                    {
                        status = false;
                        foreach (ActPluginData plugin in ActGlobals.oFormActMain.ActPlugins)
                        {
                            if (plugin.pluginFile.Name == "FFXIV_ACT_Plugin.dll" && plugin.lblPluginStatus.Text == "FFXIV Plugin Started.")
                            {
                                status = true;
                                break;
                            }
                        }
                        FFXIVPluginStatus = status;

                        if (!ReadMemory.ValidateProcessMember(ref _ffxivProcess, ref zero))
                        {
                            FFXIVPluginStatus = false;
                        }
                    }
                    else
                    {
                        FFXIVPluginStatus = false;
                    }

                    FFXIVProcess = _ffxivProcess != null ? true : false;

                    if (_ffxivProcess != null)
                    {
                        CombatantMemory.Player player = CombatantMemory.GetPlayerData(_ffxivProcess, zero);
                        LoggedIn = player.Vit > 0 ? true : false;
                    }
                    else
                    {
                        LoggedIn = false;
                    }

                    if (oldACTVisible != ACTVisible || oldFFXIVPlugin != FFXIVPluginStatus || oldFFXIVProcess != FFXIVProcess || oldLoggedIn != LoggedIn)
                        ChangedStatus(this, new EventArgs());

                    Thread.Sleep(500);
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void act_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (!logInfo.inCombat)
            {
                if (logInfo.logLine.IndexOf("パーティを解散しました。") > 0 ||
                    logInfo.logLine.IndexOf("You dissolve the party.") > 0 ||
                    logInfo.logLine.IndexOf("Vous dissolvez l'equipe.") > 0 ||
                    logInfo.logLine.IndexOf("Deine Gruppe wurde aufgelost.") > 0)
                {
                    // clear
                    PartyMemberInfo = new List<PartyMember>();
                    for (int i = 0; i < 8; i++)
                    {
                        PartyMemberInfo.Add(new PartyMember());
                    }
                    // hide at dissolution.
                    view.Hide();
                    return;
                }

                Match match = regex.Match(logInfo.logLine);
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
                                view.Adjust();
                                break;
                            case "clear":
                                PartyMemberInfo = new List<PartyMember>();
                                for (int i = 0; i < 8; i++)
                                {
                                    PartyMemberInfo.Add(new PartyMember());
                                }
                                break;
                            case "hide":
                                view.Hide();
                                break;
                            case "show":
                                view.Adjust();
                                view.TopMost = true;
                                view.Show();
                                break;
                        }
                    }
                }
            }
        }

        private void GetMemberTP()
        {
            while (!CombatantMemory.Abort)
            {
                if (stoped) break;

                if (_ffxivProcess == null)
                {
                    Thread.Sleep(3000);
                    continue;
                }

                if (PartyMemberInfo.Count == 0)
                {
                    Thread.Sleep(100);
                    continue;
                }

                List<CombatantMemory.Combatant> combatantList = CombatantMemory.GetCombatantList(_ffxivProcess, zero);
                for (int i = 0; i < PartyMemberInfo.Count; i++)
                {
                    if (combatantList.Count == 0)
                    {
                        break;
                    }

                    PartyMemberInfo[0].Name = combatantList[0].Name;

                    foreach (CombatantMemory.Combatant c in combatantList)
                    {
                        if (PartyMemberInfo[i].Name.Equals(c.Name))
                        {
                            PartyMemberInfo[i].TP = c.CurrentTP;
                            break;
                        }
                    }
                }

                OnCurrentTPUpdate();

                Thread.Sleep(1000);
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
