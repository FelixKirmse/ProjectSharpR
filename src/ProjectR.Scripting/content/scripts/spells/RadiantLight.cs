using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class RadiantLight : SpellScriptBase
    {
        public override string Name { get { return "Radiant Light"; } }
        public override string Description { get { return "A beam of holy engery radiates from the sky onto the target.\nDeals damage depending on proximity to target.\nHas a chance to paralize."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .38; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
            var damage = ((3 * cAD + 3 * cMD * (cHOL / 100) - (tDEF + tMR)) * (100 / tHOL)) / decayMod;
            TryToApplyDebuff(DebuffResistance.PAR, 25);
            DealDamage(damage);
        }
    }
}