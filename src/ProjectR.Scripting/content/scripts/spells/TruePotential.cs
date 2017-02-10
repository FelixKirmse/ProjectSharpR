using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class TruePotential : SpellScriptBase
    {
        public override string Name { get { return "True Potential"; } }
        public override string Description { get { return "Unlocks your full potential and increase all your stats."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffAllStats(caster, .75);
        }
    }
}