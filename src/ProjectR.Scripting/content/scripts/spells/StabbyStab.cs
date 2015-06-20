using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class StabbyStab : SpellScriptBase
    {
        public override string Name { get { return "Stabby Stab!"; } }
        public override string Description { get { return "Stab the target with a knife.\nVery ineffective against targets with high DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .48; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 5.5 * aAD - 2.75 * dDEF;
            DealDamage(damage);
        }
    }
}