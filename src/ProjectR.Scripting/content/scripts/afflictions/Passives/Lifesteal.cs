using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class WindFury : Affliction
    {
        public override string Name { get { return "Lifesteal"; } }

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
            attacker.Heal(damage * 0.025 * (attacker.TotalStat(EleMastery.DRK) / 100));
        }
    }
}