namespace ProjectR.Interfaces
{
    public interface ISynchronizer<TSyncValue>
    {
        void Sync(TSyncValue value);
        void AddSynchronizeable(ISynchronizeable<TSyncValue> sync);
        void ClearSynchronizeables();
    }
}