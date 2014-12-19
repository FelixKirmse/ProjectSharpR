namespace ProjectR.Interfaces
{
    public interface ISynchronizeable<TSyncValue>
    {
        void Sync(TSyncValue value);
        void SetSynchronizer(ISynchronizer<TSyncValue> syncer);
    }
}