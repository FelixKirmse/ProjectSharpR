using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class FieryRegeneration : Affliction
    {
        public override string Name { get { return "Fiery Regeneration"; } }

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
            character.Heal(character.Stats.GetTotalStat(BaseStat.HP) * .2 * (character.Stats.GetTotalStat(EleMastery.FIR) / 100));
        }
    }
}