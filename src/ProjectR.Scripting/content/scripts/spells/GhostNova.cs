using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class GhostNova : SpellScriptBase
    {
        public override string Name { get { return "Ghost Nova"; } }
        public override string Description { get { return "Unleash several ghosts to haunt your enemies.\nChance to instantly kill targets.\nHeals you for 1/4th the damage done."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 96; } }
        public override double Delay { get { return .1; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4 * cMD * (cDRK / 100) - tMR) * (100 / tDRK);
            Heal(caster, damage / 4);
            DealDamage(damage);
            TryToApplyDebuff(DebuffResistance.DTH, 66);
        }
    }
}