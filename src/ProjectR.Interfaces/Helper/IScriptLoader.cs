using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Helper
{
    public interface IScriptLoader
    {
        IEnumerable<IRaceTemplate> LoadRaceTemplates();
        IEnumerable<ISpell> LoadSpells();
    }
}