using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting.Afflictions
{
    public class ShadowWisp : Affliction
    {
        public override string Name { get { return "Shadow Wisp"; } }

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
            if (spell.SpellType == SpellType.Magical && RollPercentage(10))
            {
                var minion = SummonMinionCopyAmongEnemy(attacker, "Lingering Death");
                minion.Spells.Clear();
                AddSpell(minion, spell.Name);
                ApplyAffliction(minion, "Clearcasting");
                ApplyAffliction(minion, "Certain Death");
                SetVar(minion, "death_counter", 3);
            }
        }
    }
}