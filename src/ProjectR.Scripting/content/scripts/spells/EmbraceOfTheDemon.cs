using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class EmbraceOfTheDemon : SpellScriptBase
    {
        public override string Name { get { return "Embrace of the Demon"; } }
        public override string Description { get { return "The targets heart is embraced by demonic energy. Has a chance to instantly kill the target.\nTargets under 25% health receive triple damage."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 150; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var bonusDamage = target.CurrentHP / tHP < .25 ? 3 : 1;

            var damage = 5 * cMD * (cDRK / 100) * bonusDamage;
            TryToApplyDebuff(DebuffResistance.DTH, 50);
            DealDamage(damage);
        }
    }
}