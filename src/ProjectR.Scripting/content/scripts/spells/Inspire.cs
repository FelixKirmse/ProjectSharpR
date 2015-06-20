using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Inspire : SpellScriptBase
    {
        public override string Name { get { return "Inspire"; } }
        public override string Description { get { return "Inspire target, slightly raising their offense. Also restores some of casters MP."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {  }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.AD, .2);
            BuffStat(Stat.MD, .2);
            caster.UseMP(-(cMP * .2));
        }
    }
}