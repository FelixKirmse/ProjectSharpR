using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class Clearcasting : Affliction
    {
        public override string Name { get { return "Clearcasting"; } }

        public override AfflictionType Type { get { return AfflictionType.Buff; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new HookPoint[]
                {
                    HookPoint.UsingMP, 
                };
            }
        }

        protected override void OnUsingMP(ICharacter character, ref double value)
        {
            value = 0;
        }
    }
}