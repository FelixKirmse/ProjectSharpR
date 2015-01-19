using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DemonicStrike : SpellScriptBase
    {
        public override string Name { get { return "Demonic Strike"; } }
        public override string Description { get { return "A medium strong physical attack. It's cheap, but also not THAT effective. Get used to it!"; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {  }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 24; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.2 * cAD - .8 * tDEF;
            DealDamage(damage);
        }
    }
}