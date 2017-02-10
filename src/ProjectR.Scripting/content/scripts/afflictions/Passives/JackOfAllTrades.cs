using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class JackOfAllTrades : Affliction
    {
        public override string Name { get { return "Jack Of All Trades"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.TurnTriggered, HookPoint.BuffingStat, 
                };
            }
        }

        protected override void OnTurnTriggered(ICharacter character)
        {
            character.UseMP(-10);
        }

        protected override void OnBuffingStat(ICharacter character, ref Stat stat, ref double value)
        {
            if (value > 0)
            {
                value *= 1.5;
            }
        }
    }
}