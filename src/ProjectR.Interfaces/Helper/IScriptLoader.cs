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
    }
}