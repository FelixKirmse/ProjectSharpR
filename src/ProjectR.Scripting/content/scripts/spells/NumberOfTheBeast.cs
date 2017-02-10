using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class NumberOfTheBeast : SpellScriptBase
    {
        public override string Name { get { return "Number of the Beast"; } }
        public override string Description { get { return "A strong attack dealing high unresistable physical damage."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 120; } }
        public override double Delay { get { return .15; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 6.66 * cAD;
            DealDamage(damage);
        }
    }
}