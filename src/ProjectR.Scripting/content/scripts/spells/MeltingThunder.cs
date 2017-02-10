using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class MeltingThunder : SpellScriptBase
    {
        public override string Name { get { return "Melting Thunder"; } }
        public override string Description { get { return "Lightning strikes your target.\nThe heat melts most of their armor."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 25; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4 * cMD * (cWND / 100) - tMR) * (100 / tWND);
            BuffStat(Stat.DEF, -.8);
            DealDamage(damage);
        }
    }
}