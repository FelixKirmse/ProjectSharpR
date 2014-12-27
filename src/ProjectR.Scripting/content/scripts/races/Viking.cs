using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Viking : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Vikings developed from Humans. They have greater melee skills and can take more of a beating. Their magic skills however are below subpar. They make good tanks, but are pretty slow compared to other races. Upon evading they also perform a quick counter attack dealing damage based on the damage that would've been taken.";
            }
        }

        public string Name { get { return "Viking"; } }

        public IList<string> Passives { get { return new[] { "Counter" }; } }
        public IRaceDictionary Stats { get { return _stats; } }

        private readonly IRaceDictionary _stats = new RaceDictionary
        {
            { Stat.HP, 1.5d },
            { Stat.AD, 3d },
            { Stat.MD, .3d },
            { Stat.DEF, 3d },
            { Stat.MR, .5d },
            { Stat.SPD, .5d }
        };
    }
}