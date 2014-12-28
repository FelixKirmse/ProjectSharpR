using System.Collections.Generic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Helper
{
    public interface IScriptHelper
    {
        void ResetAllAfflictions();
        IList<IAffliction> GetAfflictions(ICharacter character);
        void DealDamage(ICharacter target, double damage);
        void Heal(ICharacter target, double healing);
        void TryToApplyDebuff(DebuffResistance type, int applyChance);
        double GetDamageTaken(ICharacter character);
    }
}