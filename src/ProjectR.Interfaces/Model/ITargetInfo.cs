namespace ProjectR.Interfaces.Model
{
    public interface ITargetInfo
    {
        ICharacter Target { get; set; }
        ISpell Spell { get; set; }
    }
}