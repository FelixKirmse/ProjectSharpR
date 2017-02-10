using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class BeerArmor : Affliction
    {
        public override string Name { get { return "Beer Armor"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.TakingDamage, 
                };
            }
        }

        protected override void OnTakingDamage(ICharacter character, ref double damage)
        {
            damage *= .9;

            if (RollPercentage(5))
            {
                ApplyAffliction(GetCurrentAttacker(), "Drunk");
            }
        }
    }
}