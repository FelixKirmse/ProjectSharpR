using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class MindStorm : SpellScriptBase
    {
        public override string Name { get { return "Mind Storm"; } }
        public override string Description { get { return "An arcane storm spreads chaos among your enemies.\nUseful against low MR enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 56; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.725 * cMD * (cARC / 100) - 1.75 * tMR) * (100 / tARC);
            DealDamage(damage);
        }
    }
}