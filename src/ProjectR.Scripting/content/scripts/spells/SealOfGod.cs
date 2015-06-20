using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SealOfGod : SpellScriptBase
    {
        public override string Name { get { return "Seal of God"; } }
        public override string Description { get { return "Tries to seal away all enemies with holy energy."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4 * aAD + 4 * aMD * (aHOL / 100) - (dDEF + dMR)) * (100 / dHOL);
            DealDamage(damage);
        }
    }
}