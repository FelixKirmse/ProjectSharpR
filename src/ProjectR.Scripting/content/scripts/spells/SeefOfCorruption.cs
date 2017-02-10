using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SeefOfCorruption : SpellScriptBase
    {
        public override string Name { get { return "Seed of Corruption"; } }
        public override string Description { get { return "Plant a seed of corruption in the target.\nThe seed explodes and damages nearby enemies."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
            var damage = ((3.75 * aMD * (aDRK / 100) - .625 * dMR) * (100 / dDRK)) / decayMod;
            DealDamage(damage);
        }
    }
}