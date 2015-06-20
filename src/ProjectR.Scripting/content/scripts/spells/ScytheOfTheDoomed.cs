using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ScytheOfTheDoomed : SpellScriptBase
    {
        public override string Name { get { return "Scythe of the Doomed"; } }
        public override string Description { get { return "Slash at the life source of your target.\nChance to instantly kill target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 32; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 2.7225 * aAD - .825 * dDEF;
            TryToApplyDebuff(DebuffResistance.DTH, 40);
            DealDamage(damage);
        }
    }
}