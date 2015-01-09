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
        void TryToApplyDebuff(ICharacter target, DebuffResistance type, int applyChance);
        double GetDamageTaken(ICharacter character);
        bool IsEnemy(ICharacter target);
        double GetVar(ICharacter target, string varName);
        void ResetDamageTaken();
        void SetVar(ICharacter target, string varName, double value);
        void ApplyAffliction(ICharacter target, string affliction);
        IEnumerable<ICharacter> GetCasterParty();
        void RemoveDebuffs(ICharacter target);
        IEnumerable<ICharacter> GetCasterReserveParty();
    }
}