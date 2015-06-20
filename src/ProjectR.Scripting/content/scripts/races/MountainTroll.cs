using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class MountainTroll : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Mountain Trolls are even more durable than normal Trolls, their bodies are made to receive and put out a lot of physical damage. Any form of magic however will quickly make short work of them. Mountain Trolls regenerate their health depending on their missing health each turn.";
            }
        }

        public string Name { get { return "Mountain Troll"; } }

        public IList<string> Passives { get { return new[] { "Aggressive Regeneration" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 5.0d },
            { Stat.AD, 2.0d },
            { Stat.MD, 0.1d },
            { Stat.DEF, 5.0d },
            { Stat.MR, 0.1d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.3d },
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