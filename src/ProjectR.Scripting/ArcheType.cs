using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public abstract class ArcheType : IArcheType
    {
        public abstract string Name { get; }
        public abstract bool Block { get; }

        protected abstract IDictionary<Stat, double> Resistances { get; }
        protected abstract IDictionary<Stat, Pair<double, double>> Stats { get; }

        public double GetBase(Stat stat)
        {
            return Stats[stat].First;
        }

        public double GetGrowth(Stat stat)
        {
            return Stats[stat].Second;
        }

        public double GetResistance(Stat stat)
        {
            return Resistances[stat];
        }
    }
}