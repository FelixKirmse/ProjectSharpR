using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class Drunk : Affliction
    {
        public override string Name { get { return "Drunk"; } }

        public override AfflictionType Type { get { return AfflictionType.Debuff; } }

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

        protected override void OnAttachment(ICharacter character)
        {
            SetVar(character, "drunk_turnCounter", 3);
        }

        protected override void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier)
        {
            var drunkCounter = GetVar(attacker, "drunk_turnCounter") - 1;
            SetVar(attacker, "drunk_turnCounter", drunkCounter);

            if (attacker.Race == "Beerman")
            {
                damage *= 1.25d;
            }
            else if (RHelper.RollPercentage(25))
            {
                damage = 0d;
            }

            if (drunkCounter > 0)
            {
                return;
            }

            RemoveFrom(attacker);
        }
    }
}