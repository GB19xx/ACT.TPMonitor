using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACT.TPMonitor
{
    public enum TYPE : byte
    {
        Player = 0x01,
        Mob = 0x02,
        NPC = 0x03,
        Aetheryte = 0x05,
        Gathering = 0x06,
        Minion = 0x09
    }
}
