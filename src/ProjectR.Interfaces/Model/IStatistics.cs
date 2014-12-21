namespace ProjectR.Interfaces.Model
{
    public interface IStatistics
    {
        void AddToStatistic(Statistic statistic, uint value);
        ulong this[Statistic statistic] { get; }
        void Reset();
    }
}