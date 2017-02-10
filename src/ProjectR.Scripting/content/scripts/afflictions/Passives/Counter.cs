using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class Counter : Affliction
    {
        public override string Name { get { return "Counter"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.AttackDodged, HookPoint.AttackBlocked, 
                };
            }
        }

        protected override void OnAttackDodged(ICharacter character, double damage)
        {
            CounterAttack(damage);
        }

        protected override void OnAttackBlocked(ICharacter character, ref double damage, ref double reduction)
        {
            CounterAttack(damage);
        }

        private void CounterAttack(double damage)
        {
            GetCurrentAttacker().TakeTrueDamage(damage * .2);
        }
    }
}