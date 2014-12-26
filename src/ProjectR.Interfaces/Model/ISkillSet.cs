using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ISkillset : INameHolder
    {
        IList<ISpell> Spells { get; }

        void AddSpell(ISpell spell);
    }
}