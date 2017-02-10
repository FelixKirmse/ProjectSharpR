using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class AggresiveRegeneration : Affliction
    {
        public override string Name { get { return "Aggressive Regeneration"; } }

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
            var amount = (character.Stats.GetTotalStat(BaseStat.HP) - character.CurrentHP) * .25;
            character.Heal(amount);
        }
    }
}