using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class SwiftFeet : Affliction
    {
        public override string Name { get { return "Swift Feet"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.RollingEvasion, 
                };
            }
        }

        protected override void OnRollingEvasion(ICharacter character, ref double evaChance)
        {
            evaChance *= 1.1;
        }
    }
}