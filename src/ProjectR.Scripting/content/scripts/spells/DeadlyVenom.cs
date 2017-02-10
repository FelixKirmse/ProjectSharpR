using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class DeadlyVenom : SpellScriptBase
    {
        public override string Name { get { return "Deadly Venom"; } }
        public override string Description { get { return "Inject the target with a deadly venom.\nAlmost guaranteed to apply PSN."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 28; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3 * cAD * (cDRK / 100) - tDEF) * (100 / tDRK);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.PSN, 120);
        }
    }
}