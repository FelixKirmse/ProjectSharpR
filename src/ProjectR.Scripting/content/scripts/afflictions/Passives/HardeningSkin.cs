using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class HardeningSkin : Affliction
    {
        public override string Name { get { return "Hardening Skin"; } }

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
            character.BuffStat(Stat.DEF, .2);
            character.BuffStat(Stat.MR, .2);
        }
    }
}