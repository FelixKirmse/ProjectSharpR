using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class LeaveCutter : SpellScriptBase
    {
        public override string Name { get { return "Leavecutter"; } }
        public override string Description { get { return "Send sharp leaves flying at the enemy.\nVery large MR piercing."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 20; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.375 * cMD * (cWND / 100) - .15 * tMR) * (100 / tWND);
            DealDamage(damage);
        }
    }
}