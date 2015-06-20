using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class AstralImprisonment : Affliction
    {
        public override string Name { get { return "Astral Imprisonment"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.Attacking, 
                };
            }
        }

        protected override void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier)
        {
            if (RollPercentage(10))
            {
                ApplyAffliction(target, "Mini Stun");
            }
        }
    }
}