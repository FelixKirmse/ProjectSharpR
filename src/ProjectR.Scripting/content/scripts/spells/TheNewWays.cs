using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class TheNewWays : SpellScriptBase
    {
        public override string Name { get { return "The New Ways"; } }
        public override string Description { get { return "A physical attack dealing magical damage to all enemies.\nWhat a twist!"; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 52; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.4225 * aAD - .925 * dMR;
            DealDamage(damage);
        }
    }
}