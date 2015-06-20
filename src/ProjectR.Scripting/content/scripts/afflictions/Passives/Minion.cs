using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class Minion : Affliction
    {
        public override string Name { get { return "Minion"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new HookPoint[]
                {
                    
                };
            }
        }

        protected override void OnAttachment(ICharacter character)
        {
            var stats = character.Stats;
            stats[BaseStat.HP][StatType.Base] *= .3;

            for (var i = BaseStat.AD; i <= BaseStat.MR; ++i)
            {
                stats[i][StatType.Base] *= .5;
            }

            character.Heal(stats.GetTotalStat(BaseStat.HP));
        }

        protected override void OnRemoval(ICharacter character)
        {
            var stats = character.Stats;
            stats[BaseStat.HP][StatType.Base] /= .3;

            for (var i = BaseStat.AD; i <= BaseStat.MR; ++i)
            {
                stats[i][StatType.Base] /= .5;
            }

            character.Heal(stats.GetTotalStat(BaseStat.HP));
        }
    }
}