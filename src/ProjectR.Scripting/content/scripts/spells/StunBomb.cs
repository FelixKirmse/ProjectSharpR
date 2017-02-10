using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class StunBomb : SpellScriptBase
    {
        public override string Name { get { return "Stun Bomb"; } }
        public override string Description { get { return "Throw a bomb at the target.\nSlightly reduces target's AD.\nTargets DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 36; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5 * aMD * (aFIR / 100) - dDEF) * (100 / dFIR);
            BuffStat(Stat.AD, -.28);
            DealDamage(damage);
        }
    }
}