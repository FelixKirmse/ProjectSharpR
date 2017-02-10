using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Tsunami : SpellScriptBase
    {
        public override string Name { get { return "Tsunami"; } }
        public override string Description { get { return "Summon a powerful Tsunami.\nReduces enemies MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WAT, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 65; } }
        public override double Delay { get { return .28; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.5 * aMD * (aWAT / 100) - 1.125 * dMR) * (100 / dWAT);
            BuffStat(Stat.MR, -.25);
            DealDamage(damage);
        }
    }
}