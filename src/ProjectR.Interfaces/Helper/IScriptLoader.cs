using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Helper
{
    public interface IScriptLoader
    {
        int RaceTemplateCount { get; }
        int SpellCount { get; }
        IEnumerable<IRaceTemplate> LoadRaceTemplates(UpdateLoadResourcesDelegate updateAction);
        IEnumerable<ISpell> LoadSpells(UpdateLoadResourcesDelegate updateAction);
        IEnumerable<IAffliction> LoadAfflictions(UpdateLoadResourcesDelegate updateAction);
        IEnumerable<IArcheType> LoadArcheTypes(UpdateLoadResourcesDelegate updateModel);
        IEnumerable<ISkillset> LoadSkillsets(UpdateLoadResourcesDelegate updateAction);
    }
}