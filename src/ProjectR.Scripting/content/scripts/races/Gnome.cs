using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Gnome : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Gnomes are said to be the result of a Dwarf mating with a human. They look pretty hilarious and are easy to kick around. Despite their appearance however they can dish out a lot of damage, while being one of the fastest races and having excellent evasive skills.";
            }
        }

        public string Name { get { return "Gnome"; } }

        public IList<string> Passives { get { return new[] { "Swift Feet" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.7d },
            { Stat.AD, 1.4d },
            { Stat.MD, 2.0d },
            { Stat.DEF, 0.7d },
            { Stat.MR, 0.7d },
            { Stat.EVA, 2.0d },
            { Stat.SPD, 1.1d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 1.0d },
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