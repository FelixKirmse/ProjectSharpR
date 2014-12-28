using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class AcidicSea : SpellScriptBase
    {
        public override string Name { get { return "Acidic Sea"; } }
        public override string Description { get { return "A sea of acid surrounds the enemy.\nLowers enemies AD."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.WAT }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                var damage = (3.0625 * MD(caster) * (WAT(caster) / 100) - .875 * MR(target)) * (100 / WAT(target));
                BuffStat(target, Stat.AD, -.18);
                DealDamage(target, damage);
            }
        }
    }
}