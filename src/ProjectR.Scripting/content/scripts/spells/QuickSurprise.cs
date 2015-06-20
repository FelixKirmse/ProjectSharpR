using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class QuickSurprise : SpellScriptBase
    {
        public override string Name { get { return "Quick Surprise"; } }
        public override string Description { get { return "A quick strike with low recovery.\nThe enemy is unable to fully prepare for the attack."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[0]; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 18; } }
        public override double Delay { get { return .85; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 2.5 * cAD - .625 * tDEF;
            DealDamage(damage);
        }
    }
}