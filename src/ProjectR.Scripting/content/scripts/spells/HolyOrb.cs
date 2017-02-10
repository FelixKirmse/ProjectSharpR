using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class HolyOrb : SpellScriptBase
    {
        public override string Name { get { return "Holy Orb"; } }
        public override string Description { get { return "An orb of pure holy power encased in a physical shell.\nCheap, but not very powerful."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 20; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.625 * cAD + 2.625 * cMD * (cHOL / 100) -
                          (0.875 * tDEF + 0.875 * tMR)) * (100 / tHOL);
            DealDamage(damage);
        }
    }
}