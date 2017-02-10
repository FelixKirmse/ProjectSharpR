using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Extinction : SpellScriptBase
    {
        public override string Name { get { return "Extinction"; } }
        public override string Description { get { return "Meteors rain down upon your enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 52; } }
        public override double Delay { get { return .15; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5.0625 * cMD * (cFIR / 100) - 1.125 * tMR) * (100/tFIR);
            DealDamage(damage);
        }
    }
}