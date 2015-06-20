using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class OrbOfFilth : SpellScriptBase
    {
        public override string Name { get { return "Orb of Filth"; } }
        public override string Description { get { return "Summon an orb of filth among the enemy ranks that explodes.\nChance to inflict poison."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2 * cMD * (cDRK / 100) - tMR) * (100 / tDRK);
            TryToApplyDebuff(DebuffResistance.PSN, 60);
            DealDamage(damage);
        }
    }
}