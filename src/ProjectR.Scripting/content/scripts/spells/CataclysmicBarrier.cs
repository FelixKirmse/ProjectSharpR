using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class CataclysmicBarrier : SpellScriptBase
    {
        public override string Name { get { return "Cataclysmic Barrier"; } }
        public override string Description { get { return "Summon a huge barrier that decreases damage done\nand increases damage taken.\nReduces AD, MD, DEF & MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 144; } }
        public override double Delay { get { return .15; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5.25 * cMD * (cHOL / 100) - 1.75 * tMR) * (100 / tHOL);
            BuffStat(Stat.AD, -.25);
            BuffStat(Stat.MD, -.25);
            BuffStat(Stat.DEF, -.25);
            BuffStat(Stat.MR, -.25);

            DealDamage(damage);
        } 
    }
}