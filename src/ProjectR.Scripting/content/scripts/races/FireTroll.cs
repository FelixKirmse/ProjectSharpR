using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class FireTroll : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Noone knows where Fire Trolls came from. They are very efficient with FIR magic and more durable against magic than normal Trolls, but a WAT spell will quickly end their life. Fire Trolls regenerate their health depending on their FIR mastery.";
            }
        }

        public string Name { get { return "Fire Troll"; } }

        public IList<string> Passives { get { return new[] { "Fiery Regeneration" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 4.0d },
            { Stat.AD, 1.0d },
            { Stat.MD, 1.0d },
            { Stat.DEF, 0.5d },
            { Stat.MR, 0.75d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 2.0d },
            { Stat.WAT, 0.1d },
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