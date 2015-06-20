using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class LightAndShadowIntertwined : SpellScriptBase
    {
        public override string Name { get { return "Light and Shadow Intertwined"; } }
        public override string Description { get { return "Twilight surrounds your enemies.\nReduces SPD and can inflict PAR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.75 * cMD * ((cHOL + cDRK) / 150) - 1.5 * tMR) * (200 / (tHOL + tDRK));
            BuffStat(Stat.SPD, -.15);
            TryToApplyDebuff(DebuffResistance.PAR, 35);
            DealDamage(damage);
        }
    }
}