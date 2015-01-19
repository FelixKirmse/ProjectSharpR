using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ForbiddenSpell42 : SpellScriptBase
    {
        public override string Name { get { return "Forbidden Spell #42"; } }
        public override string Description { get { return "Nobody knows why it is forbidden.\nIt doesn't seem particularly strong."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.75 * cMD - .75 * tMR;
            DealDamage(damage);
        }
    }
}