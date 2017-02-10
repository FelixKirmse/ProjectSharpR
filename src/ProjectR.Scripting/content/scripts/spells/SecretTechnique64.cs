using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SecretTechnique64 : SpellScriptBase
    {
        public override string Name { get { return "Secret Technique #64"; } }
        public override string Description { get { return "Strike out at all enemies using shadow energy.\nUseful against low DEF enemies."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .1; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5.25 * aAD * (aDRK / 100) - 1.75 * dDEF) * (100 / dDRK);
            DealDamage(damage);
        }
    }
}