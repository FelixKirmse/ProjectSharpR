using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class AmazingBitchSlapX11 : SpellScriptBase
    {
        public override string Name { get { return "Amazing Bitchslap X11"; } }
        public override string Description { get { return "Extend your arm to bitchslap all enemies, WTF?!"; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.DRK }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 50; } }
        public override double Delay { get { return .36; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                var damage = (5 * AD(caster) * (DRK(caster) / 100) - 1.25 * DEF(target)) * (100 / DRK(target));
                DealDamage(target, damage);
            }
        }
    }
}