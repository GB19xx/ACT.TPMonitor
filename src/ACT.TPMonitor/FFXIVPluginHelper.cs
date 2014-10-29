using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
using FFXIV_ACT_Plugin.Memory;

namespace ACT.TPMonitor
{
    public static class FFXIVPluginHelper
    {
        private static object _plugin = null;
        private static Version version;

        public static object Instance
        {
            get { return _plugin; }
            set { _plugin = value; }
        }

        public static Version Version
        {
            get { return version; }
            set { version = value; }
        }

        public static Process GetFFXIVProcess
        {
            get {
                try
                {
                    FieldInfo fi = _plugin.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var memory = fi.GetValue(_plugin);
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
            FieldInfo fi = _plugin.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var memory = fi.GetValue(_plugin);
            if (memory == null) return null;

            fi = memory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var config = fi.GetValue(memory);
            if (config == null) return null;

            fi = config.GetType().GetField("ScanCombatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var scanCombatants = fi.GetValue(config);
            if (scanCombatants == null) return null;

            return scanCombatants;
        }

        public static Player GetPlayerData()
        {
            Player player = new Player();
            try
            {
                var scanCombatants = GetScanCombatants();
                if (scanCombatants == null) return null;

                var item = scanCombatants.GetType().InvokeMember("GetPlayerData", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, scanCombatants, null);
                FieldInfo fi = item.GetType().GetField("Vit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField);
                player.Vit = (int)fi.GetValue(item);
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
}
