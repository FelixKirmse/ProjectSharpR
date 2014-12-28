using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class AlphaSlash : SpellScriptBase
    {
        public override string Name { get { return "Alpha Slash"; } }
        public override string Description { get { return "A strong physical sword slash."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {  }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod = 1)
        {
            var damage = 6 * AD(caster) - DEF(target);
            DealDamage(target, damage);
        }
    }
}