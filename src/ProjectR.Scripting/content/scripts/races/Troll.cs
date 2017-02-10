using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Troll : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Trolls are known for their incredible health, but they lack in the defensive apartment and are highly susceptible to FIR. Trolls regenerate a portion of their health each turn.";
            }
        }

        public string Name { get { return "Troll"; } }

        public IList<string> Passives { get { return new[] { "Regeneration" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 4.0d },
            { Stat.AD, 1.0d },
            { Stat.MD, 1.0d },
            { Stat.DEF, 0.5d },
            { Stat.MR, 0.5d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.2d },
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