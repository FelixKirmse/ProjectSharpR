using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SharpAssault : SpellScriptBase
    {
        public override string Name { get { return "Sharp Assault"; } }
        public override string Description { get { return "Throw magic infused knives that seek out the enemy.\nIgnores MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 68; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.3 * aAD + .825 * aMD) - .825 * dDEF;
            DealDamage(damage);
        }
    }
}