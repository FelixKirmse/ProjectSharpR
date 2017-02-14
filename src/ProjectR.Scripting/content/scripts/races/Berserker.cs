using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Berserker : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Berserkers rely on pure melee strength to completely annihilate their enemies. In return they are completely countered by any kind of magic and are unable to effectively cast spells themselves. There are some Berserkers that still try themselves in the ways of magic, but those individuals often don't last long in this world. Sometimes they lose themselves to their rage and rain down extra attacks on an enemy.";
            }
        }

        public string Name { get { return "Berserker"; } }

        public IList<string> Passives { get { return new[] { "Windfury" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.8d },
            { Stat.AD, 10.0d },
            { Stat.MD, 0.0d },
            { Stat.DEF, 2.0d },
            { Stat.MR, 0.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.5d },
            { Stat.WAT, 0.5d },
            { Stat.ICE, 0.5d },
            { Stat.ARC, 0.5d },
            { Stat.WND, 0.5d },
            { Stat.HOL, 0.5d },
            { Stat.DRK, 0.5d },
            { Stat.GRN, 0.5d },
            { Stat.LGT, 0.5d },
            { Stat.PSN, 1.0d },
            { Stat.PAR, 1.0d },
            { Stat.DTH, 1.0d },
            { Stat.SIL, 1.0d },
        };
    }
}