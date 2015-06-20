using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class StormDash : SpellScriptBase
    {
        public override string Name { get { return "Storm Dash"; } }
        public override string Description { get { return "Quickly strike all enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 50; } }
        public override double Delay { get { return .6; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.875 * aAD * (aWND / 100) - 1.25 * dDEF) * (100 / dWND);
            DealDamage(damage);
        }
    }
}