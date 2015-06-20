using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class GlimmeringTrap : SpellScriptBase
    {
        public override string Name { get { return "Glimmering Trap"; } }
        public override string Description { get { return "Trap your target with arcane energy.\nChance to inflict PAR."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 30; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5 * cAD * (cARC / 100) - 1.25 * tDEF) * (100 / tARC);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.PAR, 80);
        }
    }
}