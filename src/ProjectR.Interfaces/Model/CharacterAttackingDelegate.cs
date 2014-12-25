namespace ProjectR.Interfaces.Model
{
    public delegate void CharacterAttackingDelegate(
        ICharacter character, ICharacter target, ISpell spell, ref double damage, ref double modifier);
}