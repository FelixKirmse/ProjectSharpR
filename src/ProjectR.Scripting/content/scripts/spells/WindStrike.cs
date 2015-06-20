using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class WindStrike : SpellScriptBase
    {
        public override string Name { get { return "Wind Strike"; } }
        public override string Description { get { return "Strike with the power of the wind."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return .32; } }
        public override double Delay { get { return .65; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.3 * aAD * (aWND / 100) - dDEF) * (100 / dWND);
            DealDamage(damage);
        }
    }
}