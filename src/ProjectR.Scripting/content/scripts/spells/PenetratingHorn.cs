using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class PenetratingHorn : SpellScriptBase
    {
        public override string Name { get { return "Penetrating Horn"; } }
        public override string Description { get { return "Ram your horn into your target.\nUseful against high DEF enemies."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 36; } }
        public override double Delay { get { return .45; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.25 * cAD * (cDRK / 100) - .5 * tDEF) * (100 / tDRK);
            DealDamage(damage);
        }
    }
}