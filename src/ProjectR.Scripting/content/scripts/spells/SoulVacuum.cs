using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SoulVacuum : SpellScriptBase
    {
        public override string Name { get { return "Soul Vacuum"; } }
        public override string Description { get { return "Suck in the souls of your enemies.\nChance to instantly kill targets.\nDeals DRK damage and heals you for 1/4th the damage done."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 96; } }
        public override double Delay { get { return .1; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            TryToApplyDebuff(DebuffResistance.DTH, 66);
            var damage = (4 * aMD * (aDRK / 100) - dMR) * (100 / dDRK);
            DealDamage(damage);
            Heal(caster, damage / 4);
        }
    }
}