using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class OmniSlash : SpellScriptBase
    {
        public override string Name { get { return "Omnislash"; } }
        public override string Description { get { return "Using dark engergy, strike out at all enemies.\nIgnores a good chunk of DEF."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (6 * cAD * (cDRK / 100) - .5 * tDEF) * (100 / tDRK);
            DealDamage(damage);
        }
    }
}