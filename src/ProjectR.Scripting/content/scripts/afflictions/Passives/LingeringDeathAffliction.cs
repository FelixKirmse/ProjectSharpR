using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class LingeringDeathAffliction : Affliction
    {
        public override string Name { get { return "Lingering Death"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.Attacking, 
                };
            }
        }

        protected override void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier)
        {
            if (spell.SpellType != SpellType.Physical || !RollPercentage(10))
            {
                return;
            }

            var minion = SummonMinionCopyAmongEnemy(attacker, "Lingering Death");
            minion.Spells.Clear();
            AddSpell(minion, "Lingering Death");
            ApplyAffliction(minion, "Clearcasting");
            ApplyAffliction(minion, "Certain Death");
            SetVar(minion, "death_counter", 3);
        }
    }
}