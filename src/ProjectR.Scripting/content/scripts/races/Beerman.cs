using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Beerman : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Beermen were created, when the famous Grandmagus Robes Diegin tried to cast a spell which allowed him to live only through consuming beer. But the spell fizzled and instead created permanently drunk copy of himself. Thus the first Beerman was born. Due to their drunk nature Beermen feel considerably less pain, but are highly susceptible to any kind of status debuff. Because of walking in unpredictable patterns it is also harder to hit him.";
            }
        }

        public string Name { get { return "Beerman"; } }

        public IList<string> Passives { get { return new[] { "Beer Armor" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.0d },
            { Stat.AD, 0.6d },
            { Stat.MD, 0.6d },
            { Stat.DEF, 5.0d },
            { Stat.MR, 5.0d },
            { Stat.EVA, 2.0d },
            { Stat.SPD, 1.0d },
            { Stat.CHA, 1.0d },
            { Stat.FIR, 0.7d },
            { Stat.WAT, 0.7d },
            { Stat.ICE, 0.7d },
            { Stat.ARC, 0.7d },
            { Stat.WND, 0.7d },
            { Stat.HOL, 0.7d },
            { Stat.DRK, 0.7d },
            { Stat.GRN, 0.7d },
            { Stat.LGT, 0.7d },
            { Stat.PSN, 0.0d },
            { Stat.PAR, 0.0d },
            { Stat.DTH, 0.0d },
            { Stat.SIL, 0.0d },
        };
    }
}