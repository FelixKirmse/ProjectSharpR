using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class FrostBlast : SpellScriptBase
    {
        public override string Name { get { return "Frost Blast"; } }
        public override string Description { get { return "A chilling blast of frost."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (6.25 * cMD * (cICE / 100) - 1.25 * tMR) * (100 / tICE);
            DealDamage(damage);
        }
    }
}