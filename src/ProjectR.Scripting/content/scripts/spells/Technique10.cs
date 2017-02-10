using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Technique10 : SpellScriptBase
    {
        public override string Name { get { return "Technique #10"; } }
        public override string Description { get { return "Attack all enemies with magic-enchanted attacks."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 132; } }
        public override double Delay { get { return .2; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3 * aAD + 3 * aMD) - (dDEF + dMR);
            DealDamage(damage);
        }
    }
}