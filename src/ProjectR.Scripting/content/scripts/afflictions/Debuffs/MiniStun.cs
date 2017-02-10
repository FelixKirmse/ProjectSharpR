using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class MiniStun : Affliction
    {
        public override string Name { get { return "Mini Stun"; } }

        public override AfflictionType Type { get { return AfflictionType.Debuff; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.TurnCounterUpdating, 
                };
            }
        }

        protected override void OnAttachment(ICharacter character)
        {
            var parStrength = character.TimeToAction;
            SetVar(character, "ministun_Strength", parStrength);
        }

        protected override void OnTurnCounterUpdating(ICharacter character, BoolConsolidator result)
        {
            var timeStep = character.Stats.GetTotalStat(BaseStat.SPD);
            var currentStrength = GetVar(character, "ministun_Strength");
            var newStrength = currentStrength - timeStep;
            SetVar(character, "ministun_Strength", newStrength);

            if (newStrength <= 0)
            {
                RemoveFrom(character);
            }

            result.AddResult(false);
        }
    }
}