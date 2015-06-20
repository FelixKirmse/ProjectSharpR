using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Tornado : SpellScriptBase
    {
        public override string Name { get { return "Tornado"; } }
        public override string Description { get { return "Summon a tornado to blow your enemies away.\nIneffective against targets with high MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 30; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.5 * aMD * (aWND / 100) - 2.25 * dMR) * (100 / dWND);
            DealDamage(damage);
        }
    }
}