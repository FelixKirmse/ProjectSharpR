using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class WaveOfDarkness : SpellScriptBase
    {
        public override string Name { get { return "Wave of Darkness"; } }
        public override string Description { get { return "Similar to Tsunami, but with a different element.\nReduces enemies DEF."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 55; } }
        public override double Delay { get { return .28; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.5 * aMD * (aDRK / 100) - 1.125 * dMR) * (100 / dDRK);
            BuffStat(Stat.DEF, -.15);
            DealDamage(damage);
        }
    }
}