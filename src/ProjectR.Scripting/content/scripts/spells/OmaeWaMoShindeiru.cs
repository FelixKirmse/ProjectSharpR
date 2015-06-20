using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class OmaeWaMoShindeiru : SpellScriptBase
    {
        public override string Name { get { return "Omae Wa Mo Shindeiru"; } }
        public override string Description { get { return "You are already dead."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var bonusDamage = target.CurrentHP / tHP < .5 ? 3 : 1;

            var damage = (5 * cAD * (cDRK/100) - tDEF) * (100/tDRK) * bonusDamage;
            TryToApplyDebuff(DebuffResistance.DTH, 75);
            DealDamage(damage);
        }
    }
}