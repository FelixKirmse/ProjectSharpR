using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Backstab : SpellScriptBase
    {
        public override string Name { get { return "Backstab!"; } }
        public override string Description { get { return "Deal high composite damage to ally target. Deals no damage if used against enemies."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 10 * AD(caster) + 10 * MD(caster) - DEF(target) - MR(target);
            DealDamage(target, IsEnemy(target) ? 0d : damage);
        }
    }
}