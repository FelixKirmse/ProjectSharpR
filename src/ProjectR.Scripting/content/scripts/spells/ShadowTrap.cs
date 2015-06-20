using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ShadowTrap : SpellScriptBase
    {
        public override string Name { get { return "Shadow Trap"; } }
        public override string Description { get { return "Entrap your target and try to inject a deadly poison into it."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 32; } }
        public override double Delay { get { return .65; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 1.5 * aAD - .5 * dDEF;
            TryToApplyDebuff(DebuffResistance.PSN, 60);
            TryToApplyDebuff(DebuffResistance.PAR, 30);
            DealDamage(damage);
        }
    }
}