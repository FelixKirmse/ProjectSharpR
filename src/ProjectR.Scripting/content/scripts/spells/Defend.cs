using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Defend : SpellScriptBase
    {
        public override string Name { get { return "Defend"; } }
        public override string Description { get { return "Aquire a defensive stance, increasing DEF & MR by 20% and recovering 20% of MP"; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.DEF, .2);
            BuffStat(Stat.MR, .2);
            caster.UseMP(-(cMP * .2));
        }
    }
}