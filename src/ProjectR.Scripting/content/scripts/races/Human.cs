using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class Human : IRaceTemplate
    {
        public string Description
        {
            get
            {
                return "Humans are a very versatile race, having balanced stats and being able to pick up any combat role. Their passive allows them to use spells more often.";
            }
        }

        public string Name { get { return "Human"; } }

        public IList<string> Passives { get { return new[] { "Jack Of All Trades" }; } }
        public IRaceDictionary Stats { get { return _stats; } } 

        private readonly IRaceDictionary _stats = new RaceDictionary();
    }
}