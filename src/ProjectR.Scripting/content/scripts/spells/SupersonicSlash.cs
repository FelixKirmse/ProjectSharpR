using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SupersonicSlash : SpellScriptBase
    {
        public override string Name { get { return "Supersonic Slash"; } }
        public override string Description { get { return "Strike faster than sound, hits all enemies with immense force."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 110; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (8.325 * aAD * (aWND / 100) - 1.25 * dDEF) * (100 / dWND);
            DealDamage(damage);
        }
    }
}