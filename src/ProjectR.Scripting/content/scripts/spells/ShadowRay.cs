using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ShadowRay : SpellScriptBase
    {
        public override string Name { get { return "Shadow Ray"; } }
        public override string Description { get { return "Focus a ray of shadow energy onto target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 32; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (6.625 * aMD * (aDRK / 100) - 1.325 * dMR) * (100 / dDRK);
            DealDamage(damage);
        }
    }
}