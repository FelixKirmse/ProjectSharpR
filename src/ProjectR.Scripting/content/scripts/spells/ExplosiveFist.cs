using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ExplosiveFist : SpellScriptBase
    {
        public override string Name { get { return "Explosive Fist"; } }
        public override string Description { get { return "Attack your target with an arcane-enchanted punch.\nEnemies in proximity also take damage."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double modifier)
        {
            var damage = ((3.75 * cAD + 3.75 * cMD) * (cARC / 100) - (1.25 * tDEF + 1.25 * tMR)) * (100 / tARC) / modifier;
            DealDamage(damage);
        }
    }
}