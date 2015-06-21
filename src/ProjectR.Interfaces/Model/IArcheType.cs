using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface IArcheType : INameHolder
    {
        bool Block { get; }

        double GetBase(Stat stat);
        double GetGrowth(Stat stat);
        double GetResistance(Stat stat);
    }
}