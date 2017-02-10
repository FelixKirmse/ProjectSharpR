using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class ScriptLoader : IScriptLoader
    {
        private readonly AfflictionScriptLoader _afflictionScriptLoader = new AfflictionScriptLoader();
        private readonly ArcheTypeScriptLoader _archeTypeScriptLoader = new ArcheTypeScriptLoader();
        private readonly RaceScriptLoader _raceScriptLoader = new RaceScriptLoader();
        private readonly SkillsetScriptLoader _skillsetScriptLoader = new SkillsetScriptLoader();
        private readonly SpellScriptLoader _spellScriptLoader = new SpellScriptLoader();

        public int RaceTemplateCount { get { return _raceScriptLoader.ScriptCount; } }
        public int SpellCount { get { return _spellScriptLoader.ScriptCount; } }

        public IEnumerable<IRaceTemplate> LoadRaceTemplates(UpdateLoadResourcesDelegate updateAction)
        {
            return _raceScriptLoader.LoadScripts(updateAction);
        }

        public IEnumerable<ISpell> LoadSpells(UpdateLoadResourcesDelegate updateAction)
        {
            return _spellScriptLoader.LoadScripts(updateAction);
        }

        public IEnumerable<IAffliction> LoadAfflictions(UpdateLoadResourcesDelegate updateAction)
        {
            return _afflictionScriptLoader.LoadScripts(updateAction);
        }

        public IEnumerable<IArcheType> LoadArcheTypes(UpdateLoadResourcesDelegate updateModel)
        {
            return _archeTypeScriptLoader.LoadScripts(updateModel);
        }

        public IEnumerable<ISkillset> LoadSkillsets(UpdateLoadResourcesDelegate updateAction)
        {
            return _skillsetScriptLoader.LoadScripts(updateAction);
        }
    }
}