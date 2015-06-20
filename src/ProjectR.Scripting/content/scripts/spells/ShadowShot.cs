using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ShadowShot : SpellScriptBase
    {
        public override string Name { get { return "Shadow Shot"; } }
        public override string Description { get { return "Focus your energy into a shadowball."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 32; } }
        public override double Delay { get { return .66; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.0625 * aMD * (aDRK / 100) - .875 * dMR) * (100 / dDRK);
            DealDamage(damage);
        }
    }
}