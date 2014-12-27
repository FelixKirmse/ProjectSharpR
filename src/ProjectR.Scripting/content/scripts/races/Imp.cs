using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Imp : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Imps are small, annoying demons which are pretty versatile with magic. A dark portal lingers behind each of them that allows them to summon reinforcements during the battle.";
            }
        }

        public string Name { get { return "Imp"; } }

        public IList<string> Passives { get { return new[] { "Dark Portal" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.8d },
            { Stat.AD, 0.6d },
            { Stat.MD, 1.6d },
            { Stat.DEF, 0.7d },
            { Stat.MR, 2.0d },
            { Stat.EVA, 2.0d },
            { Stat.SPD, 1.2d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 1.0d },
            { Stat.WAT, 1.0d },
            { Stat.ICE, 1.0d },
            { Stat.ARC, 1.0d },
            { Stat.WND, 1.0d },
            { Stat.HOL, 0.5d },
            { Stat.DRK, 1.0d },
            { Stat.GRN, 1.0d },
            { Stat.LGT, 1.0d },
            { Stat.PSN, 1.0d },
            { Stat.PAR, 1.0d },
            { Stat.DTH, 1.0d },
            { Stat.SIL, 1.0d },
        };
    }
}