using System;
using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Helper
{
    public interface IScriptLoader
    {
        IEnumerable<IRaceTemplate> LoadRaceTemplates(UpdateLoadResourcesDelegate updateAction);
        IEnumerable<ISpell> LoadSpells(UpdateLoadResourcesDelegate updateAction);
        int RaceTemplateCount { get; }
        int SpellCount { get; }
        IEnumerable<IAffliction> LoadAfflictions(UpdateLoadResourcesDelegate updateAction);
        IEnumerable<IArcheType> LoadArcheTypes(UpdateLoadResourcesDelegate updateModel);
        IEnumerable<ISkillset> LoadSkillsets(UpdateLoadResourcesDelegate updateAction);
    }
}