using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Meditation : SpellScriptBase
    {
        public override string Name { get { return "Meditation"; } }
        public override string Description { get { return "A defensive stance that recovers double the MP of a normal Defend action."; } }

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
            caster.UseMP(-(cMP * .4));
        }
    }
}