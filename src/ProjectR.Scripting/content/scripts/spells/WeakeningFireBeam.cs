using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class WeakeningFireBeam : SpellScriptBase
    {
        public override string Name { get { return "Weakening Fire Beam"; } }
        public override string Description { get { return "Focus a fire beam on your target.\nSlightly lowers all stats of target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4 * aMD * (aFIR / 100) - dMR) * (100 / dFIR);
            BuffAllStats(target, -.15);
            DealDamage(damage);
        }
    }
}