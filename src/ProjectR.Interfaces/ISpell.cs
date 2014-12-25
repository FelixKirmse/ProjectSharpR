using System.Collections.Generic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces
{
    public interface ISpell
    {
        TargetType TargetType { get; }
        string Name { get; }
        string Description { get; }
        bool IsSupportSpell { get; }
        double Delay { get; }
        IList<EleMastery> Masteries { get; }
        SpellType SpellType { get; }

        double DamageCalculation(ICharacter attacker, ICharacter defender, double specialModifier = 1d);
        double GetMPCost(ICharacter caster);
        void ForceReload();
    }
}