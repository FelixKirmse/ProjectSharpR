using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Arcana : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "The Arcana are an alien race with ethereal bodies and are the absolute masters of magic in the universe. It is almost impossible to kill an Arcana with magic. Physical attacks however, are extremely efficient, since their bodies are frail and unstable. Each of their attacks have a chance to imprison the enemy in another dimension for one turn.";
            }
        }

        public string Name { get { return "Arcana"; } }

        public IList<string> Passives { get { return new[] { "Astral Imprisonment" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.4d },
            { Stat.AD, 0.2d },
            { Stat.MD, 5.0d },
            { Stat.DEF, 0.2d },
            { Stat.MR, 10.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 1.5d },
            { Stat.WAT, 1.5d },
            { Stat.ICE, 1.5d },
            { Stat.ARC, 3.0d },
            { Stat.WND, 1.5d },
            { Stat.HOL, 1.5d },
            { Stat.DRK, 1.5d },
            { Stat.GRN, 1.5d },
            { Stat.LGT, 1.5d },
            { Stat.PSN, 2.0d },
            { Stat.PAR, 2.0d },
            { Stat.DTH, 2.0d },
            { Stat.SIL, 2.0d },
        };
    }
}