using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ForbiddenSpell74 : SpellScriptBase
    {
        public override string Name { get { return "Forbidden Spell #74"; } }
        public override string Description { get { return "Through some foul magic this spell's damage is reduced by DEF.\nTargets all enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 96; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.5 * cMD - .75 * tDEF;
            DealDamage(damage);
        }
    }
}