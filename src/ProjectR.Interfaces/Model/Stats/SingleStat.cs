namespace ProjectR.Interfaces.Model.Stats
{
    /// <summary>
    /// Each stat in the struct has 8 fields.
    /// Stat[0] contains the current base value of a stat
    /// Stat[1] - Stat[3] contain the modifiers from items in the respective slot
    /// Stat[4] contains temporary battle modifiers (buffs/debuffs)
    /// Stat[5] contains the growth of a stat on levelup
    /// Stat[6] contains the stat multiplier
    /// </summary>
    public class SingleStat
    {
        private readonly double[] _statTypes = {0d, 0d, 0d, 0d, 1d, 0d, 1d};

        public double this[StatType type]
        {
            get { return _statTypes[type.AsInt()]; }
            set { _statTypes[type.AsInt()] = value; }
        }
    }
}