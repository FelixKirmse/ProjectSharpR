using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ExpectTheUnexpected : SpellScriptBase
    {
        public override string Name { get { return "Expect the Unexpected"; } }
        public override string Description { get { return "Unleash a flurry of attacks on one target.\nTargets in proximity take collateral damage.\nLargely ignores DEF."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {  }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 24; } }
        public override double Delay { get { return .66; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double modifier)
        {
            var damage = (3.3 * cAD - .25 * tDEF) / modifier;
            DealDamage(damage);
        }
    }
}