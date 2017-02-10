using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class ShadowDemon : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Shadow Demons are the masters of DRK magic spells. They are more susceptible to HOL damage than other demons. When attacking they have a chance to summon a Wisp that duplicates their attack.";
            }
        }

        public string Name { get { return "Shadow Demon"; } }

        public IList<string> Passives { get { return new[] { "Shadow Wisp" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.3d },
            { Stat.AD, 1.0d },
            { Stat.MD, 3.0d },
            { Stat.DEF, 1.0d },
            { Stat.MR, 3.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 1.0d },
            { Stat.WAT, 1.0d },
            { Stat.ICE, 1.0d },
            { Stat.ARC, 1.0d },
            { Stat.WND, 1.0d },
            { Stat.HOL, 1.1d },
            { Stat.DRK, 3.0d },
            { Stat.GRN, 1.0d },
            { Stat.LGT, 1.0d },
            { Stat.PSN, 1.0d },
            { Stat.PAR, 1.0d },
            { Stat.DTH, 1.0d },
            { Stat.SIL, 1.0d },
        };
    }
}