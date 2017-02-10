using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class LastManStanding : SpellScriptBase
    {
        public override string Name { get { return "Last Man Standing"; } }
        public override string Description { get { return "Unleash a spell that deals more damage for each of your dead party members at the front."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var deathCount = GetDeathCountOfAttackerParty();
            var damage = ((6 * deathCount) * cMD - 1.5 * tMR) * deathCount;
            DealDamage(damage);
        }
    }
}