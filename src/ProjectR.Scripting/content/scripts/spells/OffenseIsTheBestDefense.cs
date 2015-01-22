using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class OffenseIsTheBestDefense : SpellScriptBase
    {
        public override string Name { get { return "Offense Is The Best Defense"; } }
        public override string Description { get { return "Fast as the wind you attack all enemies and try to PAR them."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 80; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 6 * cAD - 1.5 * tDEF;
            TryToApplyDebuff(DebuffResistance.PAR, 20);
            DealDamage(damage);
        }
    }
}