using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface IArcheType : INameHolder
    {
        bool Block { get; set; }

        double GetBase(Stat stat);
        double GetGrowth(Stat stat);
        double GetResistance(Stat stat);

        void SetBase(Stat stat, double value);
        void SetGrowth(Stat stat, double value);
        void SetResistance(Stat stat, double value);
    }
}