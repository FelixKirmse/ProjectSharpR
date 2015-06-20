using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class MagicDampeningZone : SpellScriptBase
    {
        public override string Name { get { return "Magic Dampening Zone"; } }
        public override string Description { get { return "Summon a magic dampening zone.\nReduces enemies MD."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.0625 * cMD * (cARC / 100) - .875 * tMR) * (100 / tARC);
            BuffStat(Stat.MD, -.38);
            DealDamage(damage);
        }
    }
}