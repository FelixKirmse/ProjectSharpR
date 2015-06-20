using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class TrueForm : SpellScriptBase
    {
        public override string Name { get { return "True Form"; } }
        public override string Description { get { return "Reveal your true form, sacrificing defense for pure offense.\nThis spell has no delay."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 75; } }
        public override double Delay { get { return .99; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.SPD, 2);
            BuffStat(Stat.AD, 2);
            BuffStat(Stat.MD, 2);
            BuffStat(Stat.DEF, -2);
            BuffStat(Stat.EVA, -2);
            BuffStat(Stat.MR, -2);
        }
    }
}