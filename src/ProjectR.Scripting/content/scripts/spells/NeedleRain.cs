using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class NeedleRain : SpellScriptBase
    {
        public override string Name { get { return "Needle Rain"; } }
        public override string Description { get { return "Needles rain down from the sky upon your enemies.\nIgnores most DEF."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 72; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 3.2 * cAD - .5 * tDEF;
            DealDamage(damage);
        }
    }
}