namespace ProjectR.Interfaces.Model.Stats
{
    /// <summary>
    ///     Each stat in the struct has 8 fields.
    ///     Stat[0] contains the current base value of a stat
    ///     Stat[1] - Stat[3] contain the modifiers from items in the respective slot
    ///     Stat[4] contains temporary battle modifiers (buffs/debuffs)
    ///     Stat[5] contains the growth of a stat on levelup
    ///     Stat[6] contains the stat multiplier
    /// </summary>
    public class SingleStat
    {
        private readonly double[] _statTypes = { 0d, 0d, 0d, 0d, 1d, 0d, 1d };

        public double this[StatType type]
        {
            get { return _statTypes[type.AsInt()]; }
            set { _statTypes[type.AsInt()] = value; }
        }

        public double BasePlusGrowth()
        {
            return Base() + Growth();
        }

        public double ItemModifiers()
        {
            return Item1() + Item2() + Item3();
        }

        public double Base()
        {
            return this[StatType.Base];
        }

        public double Growth()
        {
            return this[StatType.Growth];
        }

        public double Multiplier()
        {
            return this[StatType.Multiplier];
        }

        public double Item1()
        {
            return this[StatType.Item1];
        }

        public double Item2()
        {
            return this[StatType.Item2];
        }

        public double Item3()
        {
            return this[StatType.Item3];
        }

        public double BattleMod()
        {
            return this[StatType.BattleMod];
        }

        public SingleStat Clone()
        {
            var clone = new SingleStat();
            _statTypes.CopyTo(clone._statTypes, 0);
            return clone;
        }
    }
}