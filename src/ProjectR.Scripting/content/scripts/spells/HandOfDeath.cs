using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class HandOfDeath : SpellScriptBase
    {
        public override string Name { get { return "Hand Of Death"; } }
        public override string Description { get { return "Attempt to kill all enemies.\nHigh damage modifier."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 188; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (9 * cMD * (cDRK / 100) - 1.5 * tMR) * (100 / tDRK);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.DTH, 100);
        }
    }
}