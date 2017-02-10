using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class RecklessSwing : SpellScriptBase
    {
        public override string Name { get { return "Reckless Swing"; } }
        public override string Description { get { return "Strike recklessly at your foe.\nAlso damages self slightly."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 66; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 6.5 * aAD - 1.125 * dDEF;
            var selfDamage = .16 * aAD - .2 * aDEF;
            DealDamage(caster, selfDamage);
            DealDamage(damage);
        }
    }
}