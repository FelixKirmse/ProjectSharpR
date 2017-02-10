using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SummonStorm : SpellScriptBase
    {
        public override string Name { get { return "Summon Storm"; } }
        public override string Description { get { return "Summons a relatively weak storm to attack the enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.5 * aAD * (aWND / 100) - 1.25 * dDEF) * (100 / dWND);
            DealDamage(damage);
        }
    }
}