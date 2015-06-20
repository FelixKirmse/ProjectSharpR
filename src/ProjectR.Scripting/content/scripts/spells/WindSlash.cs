using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class WindSlash : SpellScriptBase
    {
        public override string Name { get { return "Wind Slash"; } }
        public override string Description { get { return "Disturb the wind around your target.\nEnemies in proximity take reduced damage."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 144; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
            var damage = (10 * aMD * (aWND / 100) - .75 * dMR) * (100 / dWND) / decayMod;
            DealDamage(damage);
        }
    }
}