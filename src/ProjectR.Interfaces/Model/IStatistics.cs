namespace ProjectR.Interfaces.Model
{
    public interface IStatistics
    {
        ulong this[Statistic statistic] { get; }
        void AddToStatistic(Statistic statistic, uint value);
        void Reset();
    }
}