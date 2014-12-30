using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DarkMend : SpellScriptBase
    {
        public override string Name { get { return "Dark Mend"; } }
        public override string Description { get { return "Dark energy fills the air.\nDeals damage to enemies.\nHeals allies by 10% of their max HP."; } }

        public override TargetType TargetType { get { return TargetType.Everyone; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 144; } }
        public override double Delay { get { return .1; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> allies, IList<ICharacter> enemies)
        {
            foreach (var enemy in enemies)
            {
                Target = enemy;
                var damage = (4.5 * cMD * (cDRK / 100) - 1.5 * tMR) * (100 / tDRK);
                DealDamage(damage);
            }

            foreach (var ally in allies)
            {
                Heal(ally, HP(ally) * .1);
            }
        }
    }
}