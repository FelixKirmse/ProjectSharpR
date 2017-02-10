using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class MagicResistant : Affliction
    {
        public override string Name { get { return "Magic Resistant"; } }

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
            if (GetCurrentSpell().SpellType == SpellType.Magical && RollPercentage(10))
            {
                damage = 0;
            }
        }
    }
}