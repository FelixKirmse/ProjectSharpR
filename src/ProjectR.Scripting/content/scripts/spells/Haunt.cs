using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Haunt : SpellScriptBase
    {
        public override string Name { get { return "Haunt"; } }
        public override string Description { get { return "Haunt the enemy, dealing damage and healing you.\nChance to instantly kill target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .38; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.0625 * cMD * (cDRK / 100) - .875 * tMR) * (100 / tDRK);
            Heal(caster, damage);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.DTH, 75);
        }
    }
}