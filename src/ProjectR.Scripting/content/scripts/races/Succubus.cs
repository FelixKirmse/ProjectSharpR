using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Succubus : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "The succubus is a demon from legend that supposedly preys on mortal men while he sleeps; a sexual vampire of sorts. The actual name has its origins from late Latin- succuba meaning prostitute, which in turn comes from medieval Latin sub cubaire meaning 'that which lies beneath'. The Succubus is able to steal and duplicate someones soul by kissing them, creating a loyal minion that will fight for her until death.";
            }
        }

        public string Name { get { return "Succubus"; } }

        public IList<string> Passives { get { return new[] { "Kiss of Duplication" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.9d },
            { Stat.AD, 1.5d },
            { Stat.MD, 1.5d },
            { Stat.DEF, 1.0d },
            { Stat.MR, 1.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
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