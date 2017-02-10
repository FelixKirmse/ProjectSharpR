using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class DeadlySwarm : SpellScriptBase
    {
        public override string Name { get { return "Deadly Swarm"; } }
        public override string Description { get { return "A swarm of poisonous insects attacks all enemies.\nHigh chance to apply PSN."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 50; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.5 * cAD * (cDRK / 100) - tDEF) * (100 / tDRK);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.PSN, 90);
        }
    }
}