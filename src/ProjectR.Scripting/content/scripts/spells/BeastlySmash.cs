using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class BeastlySmash : SpellScriptBase
    {
        public override string Name { get { return "Beastly Smash"; } }
        public override string Description { get { return "Smash your target. Simple and easy. Relatively strong."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 30; } }
        public override double Delay { get { return .18; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod = 1)
        {
            var damage = 3.5 * AD(caster) - DEF(target);
            DealDamage(target, damage);
        }
    }
}