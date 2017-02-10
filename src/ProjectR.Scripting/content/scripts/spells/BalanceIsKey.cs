using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BalanceIsKey : SpellScriptBase
    {
        public override string Name { get { return "Balance Is Key"; } }
        public override string Description { get { return "A composite attack using both AD & MD.\nLow recovery.\nDamage depends on proximity to target."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .7; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
            var damage = (3.5 * AD(caster) + 3.5 * MD(caster) - DEF(target) - MR(target)) / decayMod;
            DealDamage(target, damage);
        }
    }
}