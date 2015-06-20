using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class IceCream : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "The Icecream People come in many flavours, but they all share a common trait: They instantly melt under FIR, but can dish out tons of ICE and WAT damage. Upon taking elemental damage they build up resistances to the element.";
            }
        }

        public string Name { get { return "The Icecream People"; } }

        public IList<string> Passives { get { return new[] { "Flavor Of The Month" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.0d },
            { Stat.AD, 1.0d },
            { Stat.MD, 1.0d },
            { Stat.DEF, 1.0d },
            { Stat.MR, 1.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.01d },
            { Stat.WAT, 2.0d },
            { Stat.ICE, 5.0d },
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