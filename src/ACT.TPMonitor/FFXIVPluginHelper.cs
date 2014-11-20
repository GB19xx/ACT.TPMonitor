using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using Advanced_Combat_Tracker;

namespace ACT.TPMonitor
{
    public static class FFXIVPluginHelper
    {
        private static Regex regVersion = new Regex(@"FileVersion: (?<version>\d+\.\d+\.\d+\.\d+)\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static ActPluginData _plugin = null;

        public static object Instance
        {
            get
            {
                if (_plugin == null && ActGlobals.oFormActMain.Visible)
                {
                    foreach (ActPluginData plugin in ActGlobals.oFormActMain.ActPlugins)
                    {
                        if (plugin.pluginFile.Name == "FFXIV_ACT_Plugin.dll" && plugin.lblPluginStatus.Text == "FFXIV Plugin Started.")
                        {
                            _plugin = plugin;
                            break;
                        }
                    }
                }
                return _plugin;
            }
        }

        public static Version GetVersion
        {
            get
            {
                if (_plugin != null)
                {
                    return new Version(regVersion.Match(_plugin.pluginVersion).Groups["version"].ToString());
                }
                return null;
            }
        }

        public static Process GetFFXIVProcess
        {
            get {
                try
                {
                    FieldInfo fi = _plugin.pluginObj.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var memory = fi.GetValue(_plugin.pluginObj);
                    if (memory == null) return null;

                    fi = memory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var config = fi.GetValue(memory);
                    if (config == null) return null;

                    fi = config.GetType().GetField("Process", BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
                    var process = fi.GetValue(config);
                    if (process == null) return null;

                    return (Process)process;
                }
                catch
                {
                    return null;
                }
            }
        }

        private static object GetScanCombatants()
        {
            FieldInfo fi = _plugin.pluginObj.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var memory = fi.GetValue(_plugin.pluginObj);
            if (memory == null) return null;

            fi = memory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var config = fi.GetValue(memory);
            if (config == null) return null;

            fi = config.GetType().GetField("ScanCombatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var scanCombatants = fi.GetValue(config);
            if (scanCombatants == null) return null;

            return scanCombatants;
        }

        public static Combatant GetPlayerData()
        {
            Combatant player = new Combatant();
            try
            {
                var scanCombatants = GetScanCombatants();
                if (scanCombatants == null) return null;

                var item = scanCombatants.GetType().InvokeMember("GetPlayerData", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, scanCombatants, null);
                FieldInfo fi = item.GetType().GetField("JobID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField);
                player.Job = (int)fi.GetValue(item);
            }
            catch { }
            return player;
        }

        public static List<Combatant> GetCombatantList()
        {
            List<Combatant> result = new List<Combatant>();
            try
            {
                var scanCombatants = GetScanCombatants();
                if (scanCombatants == null) return null;

                var item = scanCombatants.GetType().InvokeMember("GetCombatantList", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, scanCombatants, null);
                FieldInfo fi = item.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

                Type[] nestedType = item.GetType().GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                object tmp = fi.GetValue(item);
                if (tmp.GetType().IsArray)
                {
                    foreach (object temp in (Array)tmp)
                    {
                        if (temp == null) break;

                        Combatant combatant = new Combatant();

                        fi = temp.GetType().GetField("Job", BindingFlags.Public | BindingFlags.Instance);
                        combatant.Job = (int)fi.GetValue(temp);
                        fi = temp.GetType().GetField("Name", BindingFlags.Public | BindingFlags.Instance);
                        combatant.Name = (string)fi.GetValue(temp);
                        fi = temp.GetType().GetField("CurrentTP", BindingFlags.Public | BindingFlags.Instance);
                        combatant.CurrentTP = (int)fi.GetValue(temp);

                        result.Add(combatant);
                    }
                }
            }
            catch { }
            return result;
        }
    }

    public class Combatant
    {
        public uint ID;
        public uint OwnerID;
        public int Order;
        public byte type;
        public int Job;
        public int Level;
        public string Name;
        public int CurrentHP;
        public int MaxHP;
        public int CurrentMP;
        public int MaxMP;
        public int CurrentTP;
    }
}
