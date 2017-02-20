using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Vampire : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Vampires are ancient and powerful creatures of the night with a strong affinity to the DRK element. They sport a sizeable health pool and are able to heal for a percentage of all damage they do. The downside is that they have almost no defenses of any kind and anything HOL will make short work of them.";
            }
        }

        public string Name { get { return "Vampire"; } }

        public IList<string> Passives { get { return new[] { "Lifesteal" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 20.0d },
            { Stat.AD, 2.5d },
            { Stat.MD, 2.5d },
            { Stat.DEF, 0d },
            { Stat.MR, 0d },
            { Stat.EVA, 0d },
            { Stat.SPD, 1.2d },
            { Stat.CHA, 10.0d },
            { Stat.FIR, 0.5d },
            { Stat.WAT, 0.5d },
            { Stat.ICE, 0.5d },
            { Stat.ARC, 0.5d },
            { Stat.WND, 0.5d },
            { Stat.HOL, 0.01d },
            { Stat.DRK, 3.0d },
            { Stat.GRN, 0.5d },
            { Stat.LGT, 0.5d },
            { Stat.PSN, 0.2d },
            { Stat.PAR, 0.2d },
            { Stat.DTH, 10d },
            { Stat.SIL, 0.2d },
        };
    }
}