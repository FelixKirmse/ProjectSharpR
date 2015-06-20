using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Races
{
    public class Dwarf : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Dwarves are an ancient race that is said to have come from underground. They are more durable in combat. They are pretty good with GRN spells and it is almost impossible to inflict PSN on them. Their resistance to spells allows them to sometimes completely nullify spells aimed at them.";
            }
        }

        public string Name { get { return "Dwarf"; } }

        public IList<string> Passives { get { return new[] { "Magic Resistant" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.3d },
            { Stat.AD, 1.2d },
            { Stat.MD, .8d },
            { Stat.DEF, 1.5d },
            { Stat.MR, 1.2d },
            { Stat.SPD, .8d },
            { Stat.GRN, 1.7d },
            { Stat.PSN, 5d}
        };
    }
}