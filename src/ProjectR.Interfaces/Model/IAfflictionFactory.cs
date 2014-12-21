namespace ProjectR.Interfaces.Model
{
    public interface IAfflictionFactory
    {
        void LoadAfflictions();
        IAffliction GetAffliction(string name);
        void RemoveAllAfflictions();
    }
}