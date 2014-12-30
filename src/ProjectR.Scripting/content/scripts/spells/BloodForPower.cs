using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class BloodForPower : SpellScriptBase
    {
        public override string Name { get { return "Blood For Power"; } }
        public override string Description { get { return "Hit your allies with empowering magic.\nIncreases AD, MD, MR & DEF, but halves speed bar.\nDeals minor unresistable damage."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 124; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = .5 * cMD;

            BuffStat(Stat.AD, .75);
            BuffStat(Stat.MD, .75);
            BuffStat(Stat.DEF, .75);
            BuffStat(Stat.MR, .75);
            target.TurnCounter /= 2d;

            DealDamage(damage);
        }
    }
}