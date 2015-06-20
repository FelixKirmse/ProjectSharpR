using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class CertainDeath : Affliction
    {
        public override string Name { get { return "Certain Death"; } }

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

        protected override void OnTurnTriggered(ICharacter character)
        {
            var deathCounter = GetVar(character, "death_counter") - 1;
            SetVar(character, "death_counter", deathCounter);

            if (deathCounter <= 0)
            {
                character.TakeTrueDamage(character.CurrentHP * 10);
                RemoveFrom(character);
            }
        }
    }
}