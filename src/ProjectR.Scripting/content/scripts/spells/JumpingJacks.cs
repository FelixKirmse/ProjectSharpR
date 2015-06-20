using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class JumpingJacks : SpellScriptBase
    {
        public override string Name { get { return "Jumping Jacks"; } }
        public override string Description { get { return "Throw jumping jacks at an enemy."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 50; } }
        public override double Delay { get { return .2; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (7.95 * cAD * (cDRK / 100) - 1.325 * tDEF) * (100 / tDRK);
            DealDamage(damage);
        }
    }
}