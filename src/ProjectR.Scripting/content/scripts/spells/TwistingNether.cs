using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class TwistingNether : SpellScriptBase
    {
        public override string Name { get { return "Twisting Nether"; } }
        public override string Description { get { return "Twist space around your enemies, dealing high damage.\nLong delay."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 138; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (6 * aMD * (aHOL / 100) - 1.5 * dMR) * (100 / dHOL);
            DealDamage(damage);
        }
    }
}