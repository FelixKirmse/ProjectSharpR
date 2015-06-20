using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class Silence : Affliction
    {
        public override string Name { get { return "Silence"; } }

        public override AfflictionType Type { get { return AfflictionType.Debuff; } }

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

        protected override void OnAttachment(ICharacter character)
        {
            character.IsSilenced = true;
            SetVar(character, "sil_Chance", 1500);
        }

        protected override void OnRemoval(ICharacter character)
        {
            character.IsSilenced = false;
        }

        protected override void OnTurnTriggered(ICharacter character)
        {
            var silChance = GetVar(character, "sil_Chance");
            var silResi = character.Stats.GetTotalStat(DebuffResistance.SIL) * 3;

            if (RHelper.Roll(0, 99) > (silChance - silResi))
            {
                RemoveFrom(character);
            }
            else
            {
                SetVar(character, "sil_Chance", silChance / 3);
            }
        }
    }
}