namespace ProjectR.Interfaces.Model
{
    public enum HookPoints
    {
        TakingDamage,
        RollingEvasion,
        AttackDodged,
        AttackBlocked,
        Dying,
        UsingMP,
        Healing,
        ApplyingBuff,
        ApplyingDebuff,
        BuffingStat,
        RemovingDebuffs,
        RemovingBuffs,
        TurnCounterUpdating,
        TurnTriggered,
        TurnCounterUpdated,
        Attacking
    }
}