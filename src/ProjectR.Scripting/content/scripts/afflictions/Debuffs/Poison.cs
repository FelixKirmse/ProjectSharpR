using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class Poison : Affliction
    {
        public override string Name { get { return "Poison"; } }

        public override AfflictionType Type { get { return AfflictionType.Debuff; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.TurnTriggered, 
                };
            }
        }

        protected override void OnTurnTriggered(ICharacter character)
        {
            character.TakeTrueDamage(character.CurrentHP * 0.25);

            if (character.CurrentHP <= 0)
            {
                character.Heal(1);
            }
        }
    }
}