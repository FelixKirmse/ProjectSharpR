using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class InstaDeath : Affliction
    {
        public override string Name { get { return "InstaDeath"; } }

        public override AfflictionType Type { get { return AfflictionType.Debuff; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new HookPoint[]
                {
                };
            }
        }

        protected override void OnAttachment(ICharacter character)
        {
            character.TakeTrueDamage(character.CurrentHP * 10);
            RemoveFrom(character);
        }
    }
}