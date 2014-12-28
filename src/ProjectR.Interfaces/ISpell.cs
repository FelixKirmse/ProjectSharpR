using System.Collections.Generic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces
{
    public interface ISpell : INameHolder
    {
        TargetType TargetType { get; }
        string Description { get; }
        bool IsSupportSpell { get; }
        double Delay { get; }
        IList<EleMastery> Masteries { get; }
        SpellType SpellType { get; }
        double MPCost { get; }

        void Cast(ICharacter caster, IList<ICharacter> targets);
        void Cast(ICharacter caster, ICharacter target, double decayMod = 1d);
    }
}