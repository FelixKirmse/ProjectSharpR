using System;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Affliction : IAffliction
    {
        public Affliction(IModel model, string file)
        {
            throw new NotImplementedException();
        }

        public string Name { get; private set; }
        public AfflictionType Type { get; private set; }

        public void AttachTo(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void RemoveFrom(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromEveryone()
        {
            throw new NotImplementedException();
        }

        public void OnRemovingDebuffs(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void OnRemovingBuffs(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void OnTurnCounterUpdating(ICharacter character, BoolConsolidator result)
        {
            throw new NotImplementedException();
        }

        public void OnTurnTriggered(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void OnTurnCounterUpdated(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void OnDying(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void OnAttackDodged(ICharacter character, double damage)
        {
            throw new NotImplementedException();
        }

        public void OnTakingDamage(ICharacter character, ref double damage)
        {
            throw new NotImplementedException();
        }

        public void OnRollingEvasion(ICharacter character, ref double evaChance)
        {
            throw new NotImplementedException();
        }

        public void OnAttackBlocked(ICharacter character, ref double damage, ref double reduction)
        {
            throw new NotImplementedException();
        }

        public void OnUsingMP(ICharacter character, ref double value)
        {
            throw new NotImplementedException();
        }

        public void OnHealing(ICharacter character, ref double healing)
        {
            throw new NotImplementedException();
        }

        public void OnApplyingDebuff(ICharacter character, BoolConsolidator result)
        {
            throw new NotImplementedException();
        }

        public void OnApplyingBugg(ICharacter character, BoolConsolidator result)
        {
            throw new NotImplementedException();
        }

        public void OnBuffingStat(ICharacter character, ref Stat stat, ref double value)
        {
            throw new NotImplementedException();
        }

        public void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage,
                                ref double modifier)
        {
            throw new NotImplementedException();
        }

        public void ForceReload()
        {
            throw new NotImplementedException();
        }
    }
}