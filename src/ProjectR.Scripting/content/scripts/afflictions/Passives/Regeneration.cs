using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class Regeneration : Affliction
    {
        public override string Name { get { return "Regeneration"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

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
            character.Heal(character.MaxHP * .1);
        }
    }
}