using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class MysticalDragonFly : SpellScriptBase
    {
        public override string Name { get { return "Mystical Dragonfly"; } }
        public override string Description { get { return "Summon a Dragonfly to attack your enemies.\nUseful against low MR enemies.\nDeals ARC damage, but doesn't use caster Mastery."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5.25 * cMD - 1.75 * tMR) * (100 / tARC);
            DealDamage(damage);
        }
    }
}