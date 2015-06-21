using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public abstract class Skillset : ISkillset
    {
        private static readonly IScriptHelper ScriptHelper = RHelper.ScriptHelper;
        protected abstract string[] SpellNames { get; }

        public abstract string Name { get; }

        public IList<ISpell> Spells { get { return SpellNames.Select(x => ScriptHelper.GetSpell(x)).ToList(); } }
    }
}