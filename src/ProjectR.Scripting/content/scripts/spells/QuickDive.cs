using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class QuickDive : SpellScriptBase
    {
        public override string Name { get { return "Quick Dive"; } }
        public override string Description { get { return "Quickly dive at the target.\nLow delay."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[0]; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 24; } }
        public override double Delay { get { return .68; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 4 * cAD - tDEF;
            DealDamage(damage);
        }
    }
}