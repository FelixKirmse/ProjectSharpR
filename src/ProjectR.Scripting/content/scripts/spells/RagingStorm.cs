using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class RagingStorm : SpellScriptBase
    {
        public override string Name { get { return "Raging Storm"; } }
        public override string Description { get { return "Summon a storm to harm your foes.\nIgnores a good chunk of MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 38; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3 * aMD * (aWND / 100) - .45 * dMR) * (100 / dWND);
            DealDamage(damage);
        }
    }
}