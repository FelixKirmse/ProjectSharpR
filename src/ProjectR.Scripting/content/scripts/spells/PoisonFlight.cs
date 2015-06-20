using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class PoisonFlight : SpellScriptBase
    {
        public override string Name { get { return "Poison Flight"; } }
        public override string Description { get { return "Fly among the enemy ranks leaving a poison trail behind you.\nChance to inflict PAR and PSN."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 80; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4 * cAD * (cDRK / 100) - tDEF) * (100 / tDRK);
            TryToApplyDebuff(DebuffResistance.PAR, 70);
            TryToApplyDebuff(DebuffResistance.PSN, 70);
            DealDamage(damage);
        }
    }
}