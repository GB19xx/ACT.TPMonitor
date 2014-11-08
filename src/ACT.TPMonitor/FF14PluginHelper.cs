namespace ACT.TTSYukkuri
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;

    using Advanced_Combat_Tracker;

    public static class FF14PluginHelper
    {
        private static object lockObject = new object();
        private static object plugin;

        public static void Initialize()
        {
            lock (lockObject)
            {
                if (plugin != null)
                {
                    return;
                }

                if (ActGlobals.oFormActMain.Visible)
                {
                    foreach (var item in ActGlobals.oFormActMain.ActPlugins)
                    {
                        if (item.pluginFile.Name.ToUpper() == "FFXIV_ACT_Plugin.dll".ToUpper() &&
                            item.lblPluginStatus.Text.ToUpper() == "FFXIV Plugin Started.".ToUpper())
                        {
                            plugin = item.pluginObj;
                            break;
                        }
                    }
                }
            }
        }

        public static Process GetFFXIVProcess
        {
            get
            {
                try
                {
                    Initialize();

                    FieldInfo fi = plugin.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var memory = fi.GetValue(plugin);
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
            Initialize();

            FieldInfo fi = plugin.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var memory = fi.GetValue(plugin);
            if (memory == null) return null;

            fi = memory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var config = fi.GetValue(memory);
            if (config == null) return null;

            fi = config.GetType().GetField("ScanCombatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var scanCombatants = fi.GetValue(config);
            if (scanCombatants == null) return null;

            return scanCombatants;
        }

        public static List<Combatant> GetCombatantList()
        {
            Initialize();

            var result = new List<Combatant>();
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

                        var combatant = new Combatant();

                        var getValue = new Func<object, string, object>(
                            (obj, fieldName) =>
                            {
                                var fi1 = obj.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                                return fi1.GetValue(obj);
                            });

                        combatant.ID = (uint)getValue(temp, "ID");
                        combatant.Name = (string)getValue(temp, "Name");
                        combatant.type = (byte)getValue(temp, "type");
                        combatant.Level = (int)getValue(temp, "Level");

                        combatant.CurrentHP = (int)getValue(temp, "CurrentHP");
                        combatant.MaxHP = (int)getValue(temp, "MaxHP");

                        combatant.CurrentMP = (int)getValue(temp, "CurrentMP");
                        combatant.MaxMP = (int)getValue(temp, "MaxMP");

                        combatant.CurrentTP = (int)getValue(temp, "CurrentTP"); ;

                        result.Add(combatant);
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        public static List<uint> GetCurrentPartyList(
            out int partyCount)
        {
            Initialize();

            var partyList = new List<uint>();
            partyCount = 0;

            var scanCombatants = GetScanCombatants();
            if (scanCombatants == null)
            {
                return partyList;
            }

            var args = new object[]
            {
                partyCount
            };

            var modifiers1 = new ParameterModifier(1);
            modifiers1[0] = true;
            var modifiers = new ParameterModifier[]
            {
                modifiers1
            };

            var items = scanCombatants.GetType().InvokeMember(
                "GetCurrentPartyList",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod,
                null,
                scanCombatants,
                args,
                modifiers,
                CultureInfo.CurrentCulture,
                null);

            partyCount = (int)args[0];

            FieldInfo fi;

            var getValue = new Func<object, string, object>(
                (obj, fieldName) =>
                {
                    fi = obj.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                    return fi.GetValue(obj);
                });

            fi = items.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
            var itemsInner = fi.GetValue(items);

            if (itemsInner.GetType().IsArray)
            {
                foreach (var item in (Array)itemsInner)
                {
                    if (item == null)
                    {
                        break;
                    }

                    partyList.Add((uint)item);
                }
            }

            return partyList;
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
