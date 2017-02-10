using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class FireWheel : SpellScriptBase
    {
        public override string Name { get { return "Fire Wheel"; } }
        public override string Description { get { return "Spin around shrouded in fire and attack your enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 84; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = ((4 * cAD + 4 * cMD) * (cFIR / 100) - (tDEF + tMR)) * (100 / tFIR);
            DealDamage(damage);
        }
    }
}