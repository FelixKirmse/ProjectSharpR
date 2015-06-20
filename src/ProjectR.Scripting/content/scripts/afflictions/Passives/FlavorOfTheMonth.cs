using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class FlavorOfTheMonth : Affliction
    {
        public override string Name { get { return "Flavor Of The Month"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.TakingDamage, 
                };
            }
        }

        protected override void OnTakingDamage(ICharacter character, ref double damage)
        {
            var spell = GetCurrentSpell();
            var masteries = spell.Masteries;
            for (var i = Stat.FIR; i <= Stat.LGT; ++i)
            {
                if (masteries.Contains((EleMastery) i))
                {
                    character.BuffStat(i, .5);
                }
            }
        }
    }
}