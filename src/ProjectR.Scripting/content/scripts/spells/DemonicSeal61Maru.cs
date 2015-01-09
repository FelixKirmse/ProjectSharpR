using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DemonicSeal61Maru : SpellScriptBase
    {
        public override string Name { get { return "Demonic Seal 61: Maru"; } }
        public override string Description { get { return "A technique that uses HOL energy to focus down a target.\nIgnores most DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 112; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = ((1.5 * cAD + 2.25 * cMD) * (cHOL / 100) - (.15 * tDEF + .75 * tMR)) * (100 / tHOL);
            DealDamage(damage);
        }
    }
}