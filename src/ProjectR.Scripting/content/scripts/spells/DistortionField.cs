using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DistortionField : SpellScriptBase
    {
        public override string Name { get { return "Distortion Field"; } }
        public override string Description { get { return "Creates a field of arcane energy, damaging all enemies.\nSlightly ignores enemies MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 56; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.75 * cMD * (cARC/100) - .75 * tMR) * (100/tARC);
            DealDamage(damage);
        }
    }
}