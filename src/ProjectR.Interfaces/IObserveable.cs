namespace ProjectR.Interfaces
{
    public interface IObserveable
    {
        void AddObserver(IObserver observer);
        void NotifyObservers();
    }
}