namespace ProjectR.Interfaces.Model.Stats
{
    public interface IStats
    {
        double XPMultiplier { get; set; }
        EVAType EVAType { get; set; }
        SingleStat this[Stat stat] { get; set; }
        SingleStat this[BaseStat stat] { get; set; }
        SingleStat this[EleMastery stat] { get; set; }
        SingleStat this[DebuffResistance stat] { get; set; }

        double GetTotalStat(BaseStat stat);
        double GetTotalStat(EleMastery stat);
        double GetTotalStat(DebuffResistance stat);
        double GetTotalStat(Stat stat);

        void SetLvl(int level);
        void BuffStat(Stat stat, double amount);

        void ReduceBuffEffectiveness(int times = 1);
        void RemoveBuffs();
        void RemoveDebuffs();
        bool TryToApplyDebuf(DebuffResistance type, int successChance);
        double GetEVAChance(int level);

        IStats Clone();
    }
}