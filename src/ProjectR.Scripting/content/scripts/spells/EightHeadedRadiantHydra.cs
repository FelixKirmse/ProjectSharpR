using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class EightHeadedRadiantHydra : SpellScriptBase
    {
        public override string Name { get { return "8 Headed Radiant Hydra"; } }
        public override string Description { get { return "Summon a hydra to cause chaos among your enemies.\nUseful against high MR enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.HOL }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                var damage = (3.75 * MD(caster) * (HOL(caster) / 100) - .75 * MR(target)) * (100 / HOL(target));
                DealDamage(target, damage);
            }
        }
    }
}