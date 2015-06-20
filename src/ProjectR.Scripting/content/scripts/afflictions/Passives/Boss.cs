using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class Boss : Affliction
    {
        public override string Name { get { return "Boss"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.UsingMP, 
                };
            }
        }

        protected override void OnAttachment(ICharacter character)
        {
            var stats = character.Stats;
            stats[BaseStat.HP][StatType.Base] *= 20;

            for (var i = BaseStat.AD; i <= BaseStat.MR; ++i)
            {
                stats[i][StatType.Base] *= .8;
            }

            stats[DebuffResistance.DTH][StatType.Base] += 500;

            character.Heal(stats.GetTotalStat(BaseStat.HP));
        }

        protected override void OnRemoval(ICharacter character)
        {
            var stats = character.Stats;
            stats[BaseStat.HP][StatType.Base] /= 20;

            for (var i = BaseStat.AD; i <= BaseStat.MR; ++i)
            {
                stats[i][StatType.Base] /= .8;
            }

            stats[DebuffResistance.DTH][StatType.Base] -= 500;

            character.Heal(stats.GetTotalStat(BaseStat.HP));
        }

        protected override void OnUsingMP(ICharacter character, ref double value)
        {
            value = 0;
        }
    }
}