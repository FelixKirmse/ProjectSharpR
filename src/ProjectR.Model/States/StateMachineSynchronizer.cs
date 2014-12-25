using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model.States
{
    public class StateMachineSynchronizer : IStateMachineSynchronizer
    {
        private readonly List<ISynchronizeable<int>> _synchronizeables = new List<ISynchronizeable<int>>();

        public void Sync(int value)
        {
            foreach (var synchronizeable in _synchronizeables)
            {
                synchronizeable.Sync(value);
            }
        }

        public void AddSynchronizeable(ISynchronizeable<int> sync)
        {
            sync.SetSynchronizer(this);
            _synchronizeables.Add(sync);
        }

        public void ClearSynchronizeables()
        {
            _synchronizeables.Clear();
        }
    }
}