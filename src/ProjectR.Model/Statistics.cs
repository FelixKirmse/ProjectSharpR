using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Statistics : IStatistics
    {
        private readonly ulong[] _statistics = new ulong[(int) Statistic.StatisticCount];

        public void AddToStatistic(Statistic statistic, uint value)
        {
            _statistics[(int) statistic] += value;
        }

        public ulong this[Statistic statistic]
        {
            get { return _statistics[(int) statistic]; }
        }

        public void Reset()
        {
            for (var i = 0; i < (int) Statistic.StatisticCount; i++)
            {
                _statistics[i] = 0ul;
            }
        }
    }
}