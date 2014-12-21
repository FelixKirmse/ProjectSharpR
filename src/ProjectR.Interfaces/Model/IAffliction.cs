using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface IAffliction
    {
        string Name { get; }
        AfflictionType Type { get; }

        void AttachTo(ICharacter character);
        void RemoveFrom(ICharacter character);
        void RemoveFromEveryone();

        void OnRemovingDebuffs(ICharacter character);
        void OnRemovingBuffs(ICharacter character);
        void OnTurnCounterUpdating(ICharacter character, BoolConsolidator result);
        void OnTurnTriggered(ICharacter character);
        void OnTurnCounterUpdated(ICharacter character);

        void OnDying(ICharacter character);
        void OnAttackDodged(ICharacter character, double damage);

        void OnTakingDamage(ICharacter character, ref double damage);
        void OnRollingEvasion(ICharacter character, ref double evaChance);
        void OnAttackBlocked(ICharacter character, ref double damage, ref double reduction);
        void OnUsingMP(ICharacter character, ref double value);
        void OnHealing(ICharacter character, ref double healing);
        void OnApplyingDebuff(ICharacter character, BoolConsolidator result);
        void OnApplyingBugg(ICharacter character, BoolConsolidator result);
        void OnBuffingStat(ICharacter character, ref Stat stat, ref double value);
        void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier);

        void ForceReload();
    }
}