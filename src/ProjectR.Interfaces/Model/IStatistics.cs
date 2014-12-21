namespace ProjectR.Interfaces.Model
{
    public interface IStatistics
    {
        void AddToStatistic(Statistic statistic, int value);
        ulong this[Statistic statistic] { get; }
        void Reset();
    }
}