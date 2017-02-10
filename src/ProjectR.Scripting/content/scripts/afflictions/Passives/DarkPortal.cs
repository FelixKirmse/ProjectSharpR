using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class DarkPortal : Affliction
    {
        public override string Name { get { return "Dark Portal"; } }

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
            if (RollPercentage(20))
            {
                SummonMinionCopy(character, "Imp");
            }
        }
    }
}