using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class ScriptLoader : IScriptLoader
    {
        private readonly RaceScriptLoader _raceScriptLoader = new RaceScriptLoader();
        private readonly SpellScriptLoader _spellScriptLoader = new SpellScriptLoader();

        public IEnumerable<IRaceTemplate> LoadRaceTemplates()
        {
            return _raceScriptLoader.LoadScripts();
        }

        public IEnumerable<ISpell> LoadSpells()
        {
            return _spellScriptLoader.LoadScripts();
        }
    }
}