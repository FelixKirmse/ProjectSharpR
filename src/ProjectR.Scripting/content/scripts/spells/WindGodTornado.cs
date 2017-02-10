using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class WindGodTornado : SpellScriptBase
    {
        public override string Name { get { return "Wind God Tornado"; } }
        public override string Description { get { return "Summon a powerful tornado to wreak havoc among your enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 148; } }
        public override double Delay { get { return .2; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (6 * aMD * (aWND / 100) - 1.5 * dMR) * (100 / dWND);
            DealDamage(damage);
        }
    }
}