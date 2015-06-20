using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Catwalk : SpellScriptBase
    {
        public override string Name { get { return "Catwalk"; } }
        public override string Description { get { return "Swiftly attack your target.\nVery low delay.\nIgnores a bunch of DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 10; } }
        public override double Delay { get { return .9; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 1.25 * cAD - .625 * tDEF;
            DealDamage(damage);
        } 
    }
}