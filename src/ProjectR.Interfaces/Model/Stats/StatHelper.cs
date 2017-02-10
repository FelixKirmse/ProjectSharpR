using ProjectR.Interfaces.Helper;

namespace ProjectR.Interfaces.Model.Stats
{
    public static class StatHelper
    {
        private static readonly BiDictionary<string, Stat> StatBiDictionary = new BiDictionary<string, Stat>
        {
            { "HP", Stat.HP },
            { "MP", Stat.MP },
            { "AD", Stat.AD },
            { "MD", Stat.MD },
            { "DEF", Stat.DEF },
            { "MR", Stat.MR },
            { "EVA", Stat.EVA },
            { "SPD", Stat.SPD },
            { "CHA", Stat.CHA },
            { "FIR", Stat.FIR },
            { "WAT", Stat.WAT },
            { "ICE", Stat.ICE },
            { "ARC", Stat.ARC },
            { "WND", Stat.WND },
            { "HOL", Stat.HOL },
            { "DRK", Stat.DRK },
            { "GRN", Stat.GRN },
            { "LGT", Stat.LGT },
            { "PSN", Stat.PSN },
            { "PAR", Stat.PAR },
            { "SLW", Stat.SLW },
            { "STD", Stat.STD },
            { "DTH", Stat.DTH },
            { "SIL", Stat.SIL }
        };

        public static Stat StatFromString(this string str)
        {
            return StatBiDictionary[str];
        }

        public static string GetString(this Stat stat)
        {
            return StatBiDictionary[stat];
        }

        public static BaseStat AsBaseStat(this Stat stat)
        {
            return (BaseStat) stat;
        }

        public static EleMastery AsEleMastery(this Stat stat)
        {
            return (EleMastery) stat;
        }

        public static DebuffResistance AsDebuffResistance(this Stat stat)
        {
            return (DebuffResistance) stat;
        }

        public static int AsInt(this Stat stat)
        {
            return (int) stat;
        }

        public static int AsInt(this BaseStat stat)
        {
            return (int) stat;
        }

        public static int AsInt(this EleMastery stat)
        {
            return (int) stat;
        }

        public static int AsInt(this DebuffResistance stat)
        {
            return (int) stat;
        }

        public static int AsInt(this StatType type)
        {
            return (int) type;
        }
    }
}