using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BlizzardOfTheTundraWasteLand : SpellScriptBase
    {
        public override string Name { get { return "Blizzard of the Tundra Wasteland"; } }
        public override string Description { get { return "Summon a powerful blizzard which slows every enemy."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 52; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (((2.7 * cAD + 2.7 * cMD) * (cICE / 100)) - (.675 * tDEF + .675 * tMR)) * (100 / tICE);
            BuffStat(target, Stat.SPD, -.3);
            DealDamage(target, damage);
        }
    }
}