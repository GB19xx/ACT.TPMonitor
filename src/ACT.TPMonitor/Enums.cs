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

    public enum JOB : byte
    {
        Unknown = 0x0,
        GLD = 0x1,
        PGL = 0x2,
        MRD = 0x3,
        LNC = 0x4,
        ARC = 0x5,
        CNJ = 0x6,
        THM = 0x7,
        CPT = 0x8,
        BSM = 0x9,
        ARM = 0xA,
        GSM = 0xB,
        LTW = 0xC,
        WVR = 0xD,
        ALC = 0xE,
        CUL = 0xF,
        MIN = 0x10,
        BOT = 0x11,
        FSH = 0x12,
        PLD = 0x13,
        MNK = 0x14,
        WAR = 0x15,
        DRG = 0x16,
        BRD = 0x17,
        WHM = 0x18,
        BLM = 0x19,
        ACN = 0x1A,
        SMN = 0x1B,
        SCH = 0x1C
    }

    public enum Style
    {
        Normal,
        Alliance
    }
}
