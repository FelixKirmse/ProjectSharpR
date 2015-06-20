using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class WaterfallX84 : SpellScriptBase
    {
        public override string Name { get { return "Waterfall X86"; } }
        public override string Description { get { return "Out of nowhere, a fucking waterfall.\nDeals physical WAT damage, wait what?"; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WAT, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5.5 * aAD * (aWAT / 100) - 2.75 * dDEF) * (100 / dWAT);
            DealDamage(damage);
        }
    }
}