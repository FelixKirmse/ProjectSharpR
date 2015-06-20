using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ForbiddenSpell98 : SpellScriptBase
    {
        public override string Name { get { return "Forbidden Spell #98"; } }
        public override string Description { get { return "Focuses all your arcane power into\nannihilating your target.\nIgnores most of target's MR."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 10 * cMD * (cARC / 100) - .3 * tMR;
            DealDamage(damage);
        }
    }
}