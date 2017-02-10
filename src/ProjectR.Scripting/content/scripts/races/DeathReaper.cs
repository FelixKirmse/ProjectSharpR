using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class DeathReaper : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Death Reapers are notorious for their DRK melee abilities. They are similiar to Shadow Demons, but melee oriented. Each attack has a chance to leave behind a cloud of death among the enemy ranks that will continuously try to debuff the enemies.";
            }
        }

        public string Name { get { return "Death Reaper"; } }

        public IList<string> Passives { get { return new[] { "Lingering Death" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.3d },
            { Stat.AD, 3.0d },
            { Stat.MD, 1.0d },
            { Stat.DEF, 3.0d },
            { Stat.MR, 3.0d },
            { Stat.EVA, 1.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 1.0d },
            { Stat.WAT, 1.0d },
            { Stat.ICE, 1.0d },
            { Stat.ARC, 1.0d },
            { Stat.WND, 1.0d },
            { Stat.HOL, 0.1d },
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