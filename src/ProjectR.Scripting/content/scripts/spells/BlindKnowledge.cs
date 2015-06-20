using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BlindKnowledge : SpellScriptBase
    {
        public override string Name { get { return "Blind Knowledge"; } }
        public override string Description { get { return "Blindly shoots a thousand arcane projectiles in targets general direction.\nDeals more damage to enemies further away."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 32; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
            var damage = ((4 * cMD * (cARC / 100) - tMR) * (100 / tARC)) * decayMod;
            DealDamage(target, damage);
        }
    }
}