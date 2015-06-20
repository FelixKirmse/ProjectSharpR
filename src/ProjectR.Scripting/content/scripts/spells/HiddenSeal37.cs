using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class HiddenSeal37 : SpellScriptBase
    {
        public override string Name { get { return "Hidden Seal #37"; } }
        public override string Description { get { return "Something unknown surges through your enemies.\nDeals damage based on proximity to target."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 66; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double modifier)
        {
            var damage = (4 * cMD - tMR) / modifier;
            DealDamage(damage);
        }
    }
}