using System;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Model
{
    public class Stats : IStats
    {
        private readonly SingleStat[] _stats = new SingleStat[24];
        private int _currentLevel;

        public Stats()
        {
            XPMultiplier = 1d;
            _currentLevel = 0;
            for (var i = Stat.HP; i <= Stat.SIL; ++i)
            {
                this[i] = new SingleStat();
            }
        }

        public double XPMultiplier { get; set; }
        public EVAType EVAType { get; set; }

        public double GetTotalStat(Stat stat)
        {
            return stat <= Stat.CHA
                ? GetTotalStat(stat.AsBaseStat())
                : stat <= Stat.LGT
                    ? GetTotalStat(stat.AsEleMastery())
                    : stat <= Stat.SIL ? GetTotalStat(stat.AsDebuffResistance()) : 0d;
        }

        public double GetTotalStat(BaseStat stat)
        {
            var s = this[stat];
            switch (stat)
            {
                case BaseStat.HP:
                    return (s.BasePlusGrowth() * _currentLevel) *
                           ((s.Multiplier() + 0.03d * _currentLevel) + s.ItemModifiers());

                case BaseStat.MP:
                    return 200d;

                case BaseStat.EVA:
                {
                    var multiplier = s.Multiplier() + 0.02d * _currentLevel;

                    return ((s.BasePlusGrowth() * _currentLevel) * (Math.Min(multiplier, 3d) + s.ItemModifiers())) *
                           s.BattleMod();
                }

                case BaseStat.SPD:
                    return 100d + (s.Multiplier() + 0.000645d * _currentLevel) * _currentLevel * s.Growth();

                default:
                    return ((s.BasePlusGrowth() * _currentLevel) *
                            ((s.Multiplier() + 0.02d * _currentLevel) + s.ItemModifiers())) * s.BattleMod();
            }
        }

        public double GetTotalStat(EleMastery stat)
        {
            var s = this[stat];
            return (s.Base() + s.ItemModifiers()) * s.BattleMod();
        }

        public double GetTotalStat(DebuffResistance stat)
        {
            var s = this[stat];
            return (s.Base() + s.ItemModifiers()) * s.BattleMod();
        }

        public void SetLvl(int level)
        {
            if (level <= _currentLevel)
            {
                return;
            }

            _currentLevel = level;
            this[BaseStat.MP][StatType.Base] = 200d;
            this[BaseStat.MP][StatType.Multiplier] = 1d;
        }

        public void BuffStat(Stat stat, double amount)
        {
            var s = this[stat];
            s[StatType.BattleMod] += amount;
            var current = s.BattleMod();
            s[StatType.BattleMod] = current.Clamp(.5d, 2d);
        }

        public void ReduceBuffEffectiveness(int times = 1)
        {
            for (var k = 0; k < times; ++k)
            {
                foreach (var singleStat in _stats)
                {
                    var stat = singleStat.BattleMod();
                    if (stat < 1d)
                    {
                        stat += .1d;
                        stat = Math.Min(stat, 1d);
                    }
                    else if (stat > 1d)
                    {
                        stat -= .1d;
                        stat = Math.Max(stat, 1d);
                    }
                    singleStat[StatType.BattleMod] = stat;
                }
            }
        }

        public void RemoveBuffs()
        {
            foreach (var singleStat in _stats)
            {
                var stat = singleStat.BattleMod();
                singleStat[StatType.BattleMod] = Math.Min(1d, stat);
            }
        }

        public void RemoveDebuffs()
        {
            foreach (var singleStat in _stats)
            {
                var stat = singleStat.BattleMod();
                singleStat[StatType.BattleMod] = Math.Max(1d, stat);
            }
        }

        public bool TryToApplyDebuf(DebuffResistance type, int successChance)
        {
            var resistance = GetTotalStat(type) * 3;
            return RHelper.RollPercentage((int) (successChance - resistance));
        }

        public double GetEVAChance(int level)
        {
            var stat = GetTotalStat(BaseStat.EVA);
            return EVAType == EVAType.Block ? stat : stat / level;
        }

        public IStats Clone()
        {
            var clone = new Stats
            {
                EVAType = EVAType,
                XPMultiplier = XPMultiplier,
                _currentLevel = _currentLevel
            };

            for (var i = Stat.HP; i <= Stat.SIL; i++)
            {
                clone[i] = this[i].Clone();
            }

            return clone;
        }

        public static IStats GetRandomBaseStats()
        {
            var stats = new Stats();
            var hp = stats[Stat.HP];
            hp[StatType.Base] = RHelper.Roll(75, 200);
            hp[StatType.Growth] = RHelper.Roll(5, 25);

            stats[BaseStat.MP][StatType.Base] = 200d;

            for (var stat = Stat.AD; stat <= Stat.CHA; ++stat)
            {
                var s = stats[stat];
                s[StatType.Base] = RHelper.Roll(20, 80);
                s[StatType.Growth] = RHelper.Roll(1, 20);
            }

            stats.EVAType = RHelper.RollPercentage(10) ? EVAType.Block : EVAType.Dodge;

            if (stats.EVAType == EVAType.Dodge)
            {
                stats[BaseStat.EVA][StatType.Base] = 2d;
                stats[BaseStat.EVA][StatType.Growth] = RHelper.Roll(1, 8);
            }
            else
            {
                stats[BaseStat.EVA][StatType.Base] = RHelper.Roll(20, 80);
                stats[BaseStat.EVA][StatType.Growth] = RHelper.Roll(0, 1);
            }

            var spd = stats[BaseStat.SPD];
            spd[StatType.Base] = 100d;
            spd[StatType.Growth] = RHelper.Roll(5, 10);
            spd[StatType.Multiplier] = 0.0255d;

            for (var stat = Stat.FIR; stat <= Stat.LGT; ++stat)
            {
                stats[stat][StatType.Base] = RHelper.Roll(50, 200);
            }

            for (var stat = Stat.PSN; stat <= Stat.SIL; ++stat)
            {
                stats[stat][StatType.Base] = RHelper.Roll(0, 30);
            }

            stats.XPMultiplier = RHelper.Roll(80, 120) / 100d;

            return stats;
        }

        #region Indexers

        public SingleStat this[Stat stat] { get { return _stats[stat.AsInt()]; } set { _stats[stat.AsInt()] = value; } }

        public SingleStat this[BaseStat stat]
        {
            get { return _stats[stat.AsInt()]; }
            set { _stats[stat.AsInt()] = value; }
        }

        public SingleStat this[EleMastery stat]
        {
            get { return _stats[stat.AsInt()]; }
            set { _stats[stat.AsInt()] = value; }
        }

        public SingleStat this[DebuffResistance stat]
        {
            get { return _stats[stat.AsInt()]; }
            set { _stats[stat.AsInt()] = value; }
        }

        #endregion
    }
}