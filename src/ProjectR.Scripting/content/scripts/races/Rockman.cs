using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Rockman : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Rockmen are durable creatures that love punching people. They don't like magic, but are very resistant to GRN, FIR and LGT. WAT, however corrodes their skin. Rockmen sometimes completely shrug of physical attacks";
            }
        }

        public string Name { get { return "Rockman"; } }

        public IList<string> Passives { get { return new[] { "Rock Hard" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.4d },
            { Stat.AD, 2.2d },
            { Stat.MD, 0.5d },
            { Stat.DEF, 2.4d },
            { Stat.MR, 0.5d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 2.0d },
            { Stat.WAT, 0.5d },
            { Stat.ICE, 1.0d },
            { Stat.ARC, 1.0d },
            { Stat.WND, 1.0d },
            { Stat.HOL, 1.0d },
            { Stat.DRK, 1.0d },
            { Stat.GRN, 3.0d },
            { Stat.LGT, 2.0d },
            { Stat.PSN, 1.0d },
            { Stat.PAR, 1.0d },
            { Stat.DTH, 1.0d },
            { Stat.SIL, 1.0d },
        };
    }
}