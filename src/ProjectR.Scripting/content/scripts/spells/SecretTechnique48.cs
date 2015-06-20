using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SecretTechnique48 : SpellScriptBase
    {
        public override string Name { get { return "Secret Technique #48"; } }
        public override string Description { get { return "An attack that is enhanced by darkness."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK,  }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.5 * aAD * (aDRK / 100) - 1.125 * dDEF) * (100 / dDRK);
            DealDamage(damage);
        }
    }
}