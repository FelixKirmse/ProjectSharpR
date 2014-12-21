using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ISkillset
    {
        string Name { get; }
        IList<ISpell> Spells { get; }

        void AddSpell(ISpell spell);
    }
}