using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class TicklingNeedles : SpellScriptBase
    {
        public override string Name { get { return "Tickling Needles"; } }
        public override string Description { get { return "Throw magic infused needles at your enemies.\nWeak but cheap."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 24; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (1.875 * aAD + .625 * aMD) - (.625 * dDEF + .3125 * dMR);
            DealDamage(damage);
        }
    }
}