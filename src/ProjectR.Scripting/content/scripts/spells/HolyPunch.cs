using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class HolyPunch : SpellScriptBase
    {
        public override string Name { get { return "Holy Punch"; } }
        public override string Description { get { return "Punch the enemy with a holy-infused fist."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 20; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 4.5 * cAD * (cHOL / 100) - 1.5 * tDEF;
            DealDamage(damage);
        }
    }
}