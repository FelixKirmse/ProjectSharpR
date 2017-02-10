using System.Collections.Generic;
using ProjectR.Interfaces;

namespace ProjectR.Model
{
    public class Observeable : IObserveable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Notify();
            }
        }
    }
}