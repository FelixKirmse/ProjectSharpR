using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Bash : SpellScriptBase
    {
        public override string Name { get { return "Bash"; } }
        public override string Description { get { return "Bash your target, dazing it."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = .5 * AD(caster) - DEF(target);
            ApplyAffliction(target, "Mini Stun");
            SetVar(target, "ministun_Strength", GetVar(target, "ministun_Strength") * .2);
            DealDamage(target, damage);
        }
    }
}