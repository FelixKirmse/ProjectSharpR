using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ChaosBarrier : SpellScriptBase
    {
        public override string Name { get { return "Chaos Barrier"; } }
        public override string Description { get { return "Summon a small barrier that decreases damage done\nand increases damage taken.\nReduces AD, MD, DEF & MR."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.75 * cMD * (cHOL / 100) - 1.25 * tMR) * (100 / tHOL);
            BuffStat(Stat.AD, -.15);
            BuffStat(Stat.MD, -.15);
            BuffStat(Stat.DEF, -.15);
            BuffStat(Stat.MR, -.15);

            DealDamage(damage);
        } 
    }
}