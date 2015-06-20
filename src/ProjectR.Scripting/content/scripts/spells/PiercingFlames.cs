using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class PiercingFlames : SpellScriptBase
    {
        public override string Name { get { return "Piercing Flames"; } }
        public override string Description { get { return "Piercing hot flames attack all enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 2.5 * cMD * (cFIR / 100);
            DealDamage(damage);
        }
    }
}