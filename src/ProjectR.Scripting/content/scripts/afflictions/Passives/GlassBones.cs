using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class GlassBones : Affliction
    {
        public override string Name { get { return "Glass Bones"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.Attacking, 
                    HookPoint.TakingDamage, 
                };
            }
        }

        protected override void OnTakingDamage(ICharacter character, ref double damage)
        {
            damage += 1.1;
        }

        protected override void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier)
        {
            if (RollPercentage(25))
            {
                attacker.TakeTrueDamage(attacker.Stats.GetTotalStat(BaseStat.HP) * .1);
            }
        }
    }
}