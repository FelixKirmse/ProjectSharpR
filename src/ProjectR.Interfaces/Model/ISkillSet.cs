using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ISkillSet
    {
        string Name { get; }
        IList<ISpell> Spells { get; }

        void AddSpell(ISpell spell);
    }
}