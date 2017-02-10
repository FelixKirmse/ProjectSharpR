using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class RiseOfThePhoenix : Affliction
    {
        public override string Name { get { return "Rise of the Phoenix"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.Dying, 
                };
            }
        }

        protected override void OnDying(ICharacter character)
        {
            character.Heal(character.MaxHP);
            character.UseMP(-200);

            for (var i = Stat.HP; i <= Stat.SIL; ++i)
            {
                character.BuffStat(i, 2);
            }

            RemoveFrom(character);
        }
    }
}