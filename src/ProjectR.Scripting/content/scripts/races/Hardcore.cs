using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Hardcore : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "The Hardcore love challenges and don't mind to go through pain and suffering to succeed in them. Despite their lackluster attributes in all aspects they managed to not get completely wiped off the face of the planet yet. Their Glass Bones passive gives every attack a chance to hurt themselves and they take more damage when being attacked.";
            }
        }

        public string Name { get { return "Hardcore"; } }

        public IList<string> Passives { get { return new[] { "Glass Bones" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 0.5d },
            { Stat.AD, 0.5d },
            { Stat.MD, 0.5d },
            { Stat.DEF, 0.5d },
            { Stat.MR, 0.5d },
            { Stat.EVA, 0.5d },
            { Stat.SPD, 0.5d },
            { Stat.CHA, 0.5d },
            { Stat.FIR, 0.5d },
            { Stat.WAT, 0.5d },
            { Stat.ICE, 0.5d },
            { Stat.ARC, 0.5d },
            { Stat.WND, 0.5d },
            { Stat.HOL, 0.5d },
            { Stat.DRK, 0.5d },
            { Stat.GRN, 0.5d },
            { Stat.LGT, 0.5d },
            { Stat.PSN, 0.5d },
            { Stat.PAR, 0.5d },
            { Stat.DTH, 0.5d },
            { Stat.SIL, 0.5d },
        };
    }
}