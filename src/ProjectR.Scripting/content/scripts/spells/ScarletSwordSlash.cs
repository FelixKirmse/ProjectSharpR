using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ScarletSwordSlash : SpellScriptBase
    {
        public override string Name { get { return "Scarlet Sword Slash"; } }
        public override string Description { get { return "Slash your scarlet sword at the enemy.\nUseful on high DEF enemies."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 52; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.5 * aAD - .4375 * dDEF;
            DealDamage(damage);
        }
    }
}