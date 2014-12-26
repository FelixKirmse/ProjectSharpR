namespace ProjectR.Interfaces.Model
{
    public interface ICharacterEvents
    {
        event CharacterTakingDamageDelegate TakingDamage;
        event CharacterRollingEvasionDelegate RollingEvasion;
        event CharacterDodgedAttackDelegate AttackDodged;
        event CharacterBlockedAttackDelegate AttackBlocked;
        event CharacterEventDelegate Dying;
        event CharacterUsingMPDelegate UsingMP;
        event CharacterHealingDelegate Healing;
        event CharacterBuffingStatDelegate BuffingStat;
        event CharacterEventDelegate RemovingDebuffs;
        event CharacterEventDelegate RemovingBuffs;
        event CharacterEventDelegate TurnTriggered;
        event CharacterEventDelegate TurnCounterUpdated;
        event CharacterAttackingDelegate Attacking;
        event CharacterBooleanEventDelegate ApplyingDebuff;
        event CharacterBooleanEventDelegate ApplyingBuff;
        event CharacterBooleanEventDelegate TurnCounterUpdating;

        void FireAttackingEvent(ICharacter character, ICharacter target, ISpell spell, ref double damage,
                                ref double modifier);
    }
}