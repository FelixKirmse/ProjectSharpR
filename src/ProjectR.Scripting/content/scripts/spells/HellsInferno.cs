using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class HellsInferno : SpellScriptBase
    {
        public override string Name { get { return "Hell's Inferno"; } }
        public override string Description { get { return "An inferno from hell appears below the enemies.\nDecreases MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 112; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.5 * cMD * (cFIR / 100) - 1.5 * tMR) * (100 / tFIR);
            BuffStat(Stat.MR, -.25);
            DealDamage(damage);
        }
    }
}