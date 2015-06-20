namespace ProjectR.Interfaces.Model
{
    public interface IAffliction
    {
        string Name { get; }
        AfflictionType Type { get; }

        void AttachTo(ICharacter character);
        void RemoveFrom(ICharacter character);
        void RemoveFromEveryone();
    }
}