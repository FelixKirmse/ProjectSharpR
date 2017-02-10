using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public static class ScriptExtensions
    {
        public static double TotalStat(this ICharacter character, Stat stat)
        {
            return character.Stats.GetTotalStat(stat);
        }

        public static double TotalStat(this ICharacter character, BaseStat stat)
        {
            return character.Stats.GetTotalStat(stat);
        }

        public static double TotalStat(this ICharacter character, EleMastery stat)
        {
            return character.Stats.GetTotalStat(stat);
        }

        public static double TotalStat(this ICharacter character, DebuffResistance stat)
        {
            return character.Stats.GetTotalStat(stat);
        }
    }
}