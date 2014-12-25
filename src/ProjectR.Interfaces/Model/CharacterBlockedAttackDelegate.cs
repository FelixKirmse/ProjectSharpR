namespace ProjectR.Interfaces.Model
{
    public delegate void CharacterBlockedAttackDelegate(
        ICharacter character, ref double origDamage, ref double damageReduction);
}