using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class RockHard : Affliction
    {
        public override string Name { get { return "Rock Hard"; } }

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
            if (GetCurrentSpell().SpellType == SpellType.Physical && RollPercentage(20))
            {
                damage = 0;
            }
        }
    }
}