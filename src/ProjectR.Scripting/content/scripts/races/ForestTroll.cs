using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class ForestTroll : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "The common Forest Troll has less health than a normal Troll, is more susceptible to FIR and physical damage, but is good with magical spells. Forest Trolls regenerate a small portion of their missing health and energy each turn.";
            }
        }

        public string Name { get { return "Forest Troll"; } }

        public IList<string> Passives { get { return new[] { "Rejuvenation" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 3.2d },
            { Stat.AD, 0.7d },
            { Stat.MD, 1.5d },
            { Stat.DEF, 0.3d },
            { Stat.MR, 1.2d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.1d },
            { Stat.WAT, 1.0d },
            { Stat.ICE, 1.0d },
            { Stat.ARC, 1.0d },
            { Stat.WND, 1.0d },
            { Stat.HOL, 1.0d },
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