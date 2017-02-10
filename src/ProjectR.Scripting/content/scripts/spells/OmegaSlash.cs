using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class OmegaSlash : SpellScriptBase
    {
        public override string Name { get { return "Omega Slash"; } }
        public override string Description { get { return "Attempts to execute the target.\nLess effective against enemies with high DEF.\nDeals triple damage to targets below 25%% HP."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .1; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var bonusDamage = target.CurrentHP / tHP < .25 ? 3 : 1;

            var damage = (11.25 * cAD - 1.5 * tDEF) * bonusDamage;
            DealDamage(damage);
        }
    }
}