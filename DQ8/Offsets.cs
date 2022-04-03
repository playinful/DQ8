using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// playinful: these are my own custom classes, made to manage both JP and NA offset data.

namespace DQ8
{
    public static class Offsets
    {
        public static Dictionary<string, OffsetData> JP_Offsets = new Dictionary<string, OffsetData>{
            {"PlayTime"         , new OffsetData(0x2C48,4 )},
            {"HeroName"         , new OffsetData(0x09F8,8 )},
            {"BattleCount"      , new OffsetData(0x37FC,4 )},
            {"GoldHand"         , new OffsetData(0x0A08,4 )},
            {"GoldBank"         , new OffsetData(0x0A0C,4 )},
            {"CasinoCoin"       , new OffsetData(0x1564,4 )},
            {"SmallMedal"       , new OffsetData(0x2B64,4 )},
            {"KillCount"        , new OffsetData(0x3800,4 )},
            {"WardOffCount"     , new OffsetData(0x3804,4 )},
            {"EscapeCount"      , new OffsetData(0x3808,4 )},
            {"VictoryCount"     , new OffsetData(0x380C,4 )},
            {"AnnihilationCount", new OffsetData(0x3810,4 )},
            {"TotalGold"        , new OffsetData(0x3814,4 )},
            {"MaxDamage"        , new OffsetData(0x381C,4 )},
            {"TermName1"        , new OffsetData(0x13A8,18)},
            {"TermName2"        , new OffsetData(0x13CC,18)},
            {"Term11"           , new OffsetData(0x13C0,1 )},
            {"Term12"           , new OffsetData(0x13C2,1 )},
            {"Term13"           , new OffsetData(0x13C4,1 )},
            {"Term21"           , new OffsetData(0x13E4,1 )},
            {"Term22"           , new OffsetData(0x13E6,1 )},
            {"Term23"           , new OffsetData(0x13E8,1 )},
            {"Alchemy"          , new OffsetData(0x2B56,1 )},
            {"TermMake"         , new OffsetData(0x0100,2 )},
            {"TermCall"         , new OffsetData(0x04D6,0 )},
            {"ItemAddress"      , new OffsetData(0x0ADC   )}, // 2780
            {"Place"            , new OffsetData(0x2B34   )},
            {"AlchemyBook"      , new OffsetData(0x10208  )},
            {"DefeatedMonster"  , new OffsetData(0x2D9C   )},
            {"CollectedItem"    , new OffsetData(0x11B0   )},
            {"BattleMonster"    , new OffsetData(0x13F0   )},
            {"Order"            , new OffsetData(0x11A0   )},
            // Party member values
            // PartyStatus
            {"PartyStatus"      , new OffsetData(0x11EC,64)},
            {"PartyHP"          , new OffsetData(0x0   ,2 )},
            {"PartyMP"          , new OffsetData(0x8   ,2 )},
            {"PartyLv"          , new OffsetData(0x14  ,2 )},
            {"PartyExp"         , new OffsetData(0xC   ,4 )},
            {"PartyPower"       , new OffsetData(0x16  ,2 )},
            {"PartyDefense"     , new OffsetData(0x18  ,2 )},
            {"PartySpeed"       , new OffsetData(0x1A  ,2 )},
            {"PartyCool"        , new OffsetData(0x1C  ,2 )},
            {"PartyHPPlus"      , new OffsetData(0x20  ,2 )},
            {"PartyMPPlus"      , new OffsetData(0x22  ,2 )},
            {"PartyPowerPlus"   , new OffsetData(0x24  ,2 )},
            {"PartyDefensePlus" , new OffsetData(0x26  ,2 )},
            {"PartySpeedPlus"   , new OffsetData(0x28  ,2 )},
            {"PartyCoolPlus"    , new OffsetData(0x2A  ,2 )},
            {"PartySkillPlus"   , new OffsetData(0x36  ,2 )},
            // PartyItem
            {"PartyItem"        , new OffsetData(0x0A10,34)},
            {"PartyWeapon"      , new OffsetData(0x18  ,2 )},
            {"PartyArmor"       , new OffsetData(0x1A  ,2 )},
            {"PartyShield"      , new OffsetData(0x1C  ,2 )},
            {"PartyHelmet"      , new OffsetData(0x1E  ,2 )},
            {"PartyAccessory"   , new OffsetData(0x20  ,2 )}
        };
        public static Dictionary<string, OffsetData> NA_Offsets = new Dictionary<string, OffsetData>{
            {"PlayTime"         , new OffsetData(0x2CA0,4 )},
            {"HeroName"         , new OffsetData(0x09F8,22)},
            {"BattleCount"      , new OffsetData(0x3894,4 )},
            {"GoldHand"         , new OffsetData(0x0A10,4 )},
            {"GoldBank"         , new OffsetData(0x0A14,4 )},
            {"CasinoCoin"       , new OffsetData(0x15BC,4 )},
            {"SmallMedal"       , new OffsetData(0x2BBC,4 )},
            {"KillCount"        , new OffsetData(0x3898,4 )},
            {"WardOffCount"     , new OffsetData(0x389C,4 )},
            {"EscapeCount"      , new OffsetData(0x38A0,4 )},
            {"VictoryCount"     , new OffsetData(0x38A4,4 )},
            {"AnnihilationCount", new OffsetData(0x38A8,4 )},
            {"TotalGold"        , new OffsetData(0x38AC,4 )},
            {"MaxDamage"        , new OffsetData(0x38B4,4 )},
            {"TermName1"        , new OffsetData(0x13B0,64)},
            {"TermName2"        , new OffsetData(0x13FC,64)},
            {"Term11"           , new OffsetData(0x13F0,1 )},
            {"Term12"           , new OffsetData(0x13F2,1 )},
            {"Term13"           , new OffsetData(0x13F4,1 )},
            {"Term21"           , new OffsetData(0x143C,1 )},
            {"Term22"           , new OffsetData(0x143E,1 )},
            {"Term23"           , new OffsetData(0x1440,1 )},
            {"Alchemy"          , new OffsetData(0x2BAE,1 )},
            {"TermMake"         , new OffsetData(0x0100,1 )},
            {"TermCall"         , new OffsetData(0x04D6,0 )},
            {"ItemAddress"      , new OffsetData(0x0AE4   )}, // 2788
            {"Place"            , new OffsetData(0x2B8C   )},
            {"AlchemyBook"      , new OffsetData(0x102A0  )},
            {"DefeatedMonster"  , new OffsetData(0x2E34   )},
            {"CollectedItem"    , new OffsetData(0x11B8   )},
            {"BattleMonster"    , new OffsetData(0x1448   )},
            {"Order"            , new OffsetData(0x11A8   )},
            // Party member values
            // PartyStatus
            {"PartyStatus"      , new OffsetData(0x11F0,64)},
            {"PartyHP"          , new OffsetData(0x0   ,2 )},
            {"PartyMP"          , new OffsetData(0x8   ,2 )},
            {"PartyLv"          , new OffsetData(0x18  ,2 )},
            {"PartyExp"         , new OffsetData(0x10  ,4 )},
            {"PartyPower"       , new OffsetData(0x1A  ,2 )},
            {"PartyDefense"     , new OffsetData(0x1C  ,2 )},
            {"PartySpeed"       , new OffsetData(0x1E  ,2 )},
            {"PartyCool"        , new OffsetData(0x20  ,2 )},
            {"PartyHPPlus"      , new OffsetData(0x24  ,2 )},
            {"PartyMPPlus"      , new OffsetData(0x26  ,2 )},
            {"PartyPowerPlus"   , new OffsetData(0x28  ,2 )},
            {"PartyDefensePlus" , new OffsetData(0x2A  ,2 )},
            {"PartySpeedPlus"   , new OffsetData(0x2C  ,2 )},
            {"PartyCoolPlus"    , new OffsetData(0x2E  ,2 )},
            {"PartySkillPlus"   , new OffsetData(0x3A  ,2 )},
            {"PartySkillAddress", new OffsetData(0x30  ,2 )},
            // PartyItem
            {"PartyItem"        , new OffsetData(0x0A18,34)},
            {"PartyWeapon"      , new OffsetData(0x18  ,2 )},
            {"PartyArmor"       , new OffsetData(0x1A  ,2 )},
            {"PartyShield"      , new OffsetData(0x1C  ,2 )},
            {"PartyHelmet"      , new OffsetData(0x1E  ,2 )},
            {"PartyAccessory"   , new OffsetData(0x20  ,2 )}
        };

        public static Dictionary<string, OffsetData> GetOffsetsByMode()
        {
            switch(Info.Instance().Mode)
            {
                case "NA":
                default:
                    return NA_Offsets;
                case "JP":
                    return JP_Offsets;
            }
        }
        public static OffsetData GetOffsetData(string key)
        {
            if (GetOffsetsByMode().ContainsKey(key))
                return GetOffsetsByMode()[key];
            else
                return null;
        }
        public static uint GetAddress(string key)
        {
            if (GetOffsetsByMode().ContainsKey(key))
                return GetOffsetsByMode()[key].Start;
            else
                return 0;
        }
        public static uint GetLength(string key)
        {
            if (GetOffsetsByMode().ContainsKey(key))
                return GetOffsetsByMode()[key].Length;
            else
                return 0;
        }
    }
    public class OffsetData
    {
        public uint Start { get; set; }
        public uint Length { get; set; }
        public OffsetData(uint start, uint length = 0)
        {
            Start = start;
            Length = length;
        }
    }
}
