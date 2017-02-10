using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class CaveTroll : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Cave trolls are massive, tank-like creatures that are found in caves deep underground. They are unlike normal Trolls in that they possess only little health, but have massive defensive powers and their skin only hardens more during battle.";
            }
        }

        public string Name { get { return "Cave Troll"; } }

        public IList<string> Passives { get { return new[] { "Hardening Skin" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.3d },
            { Stat.AD, 1.0d },
            { Stat.MD, 1.0d },
            { Stat.DEF, 20.0d },
            { Stat.MR, 20.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
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