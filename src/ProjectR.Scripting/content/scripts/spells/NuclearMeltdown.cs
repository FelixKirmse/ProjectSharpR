using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class NuclearMeltdown : SpellScriptBase
    {
        public override string Name { get { return "Nuclear Meltdown"; } }
        public override string Description { get { return "Overheat yourself, sacrificing DEF & MR for MD.\nAlso deals FIR damage to all enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 8; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            BuffStat(caster, Stat.MD, .35);
            BuffStat(caster, Stat.MR, -.2);
            BuffStat(caster, Stat.DEF, -.2);

            base.SpellEffect(caster, targets);
        }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.25 * cMD * (cFIR / 100) - .75 * tMR) * (100 / tFIR);
            DealDamage(damage);
        }
    }
}