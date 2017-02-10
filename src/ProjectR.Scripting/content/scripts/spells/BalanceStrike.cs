using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BalanceStrike : SpellScriptBase
    {
        public override string Name { get { return "Balance Strike"; } }
        public override string Description { get { return "A strike that combines HOL and DRK, magic and physical,\nin order to achieve true balance."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 92; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                var damage = ((3 * AD(caster) + 3 * MD(caster)) * ((HOL(caster) + DRK(caster)) / 200) -
                              (.75 * DEF(target) + .75 * MR(target))) * (200 / (DRK(target) + HOL(target)));
                DealDamage(target, damage);
            }
        }
    }
}