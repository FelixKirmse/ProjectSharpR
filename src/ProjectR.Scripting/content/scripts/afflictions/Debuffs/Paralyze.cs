using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class Paralyze : Affliction
    {
        public override string Name { get { return "Paralyze"; } }

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
            var charPAR = character.Stats.GetTotalStat(DebuffResistance.PAR) * 3;
            if (charPAR < 20)
            {
                charPAR = 20;
            }

            var parStrength = character.TimeToAction * (100 / charPAR);
            SetVar(character, "par_Strength", parStrength);
        }

        protected override void OnTurnCounterUpdating(ICharacter character, BoolConsolidator result)
        {
            var timeStep = character.Stats.GetTotalStat(BaseStat.SPD);
            var currentStrength = GetVar(character, "par_Strength");
            var newStrength = currentStrength - timeStep;
            SetVar(character, "par_Strength", newStrength);

            if (newStrength <= 0)
            {
                RemoveFrom(character);
            }
            result.AddResult(false);
        }
    }
}