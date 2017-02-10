using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class EmpoweringLaser : SpellScriptBase
    {
        public override string Name { get { return "Empowering Laser"; } }
        public override string Description { get { return "Cast a massive arcane laser.\nOnly effective against low MR enemies. Increases your MR."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5 * cMD * (cARC / 100) - 2.5 * tMR) * (100 / tARC);
            BuffStat(caster, Stat.MR, .25);
            DealDamage(damage);
        }
    }
}