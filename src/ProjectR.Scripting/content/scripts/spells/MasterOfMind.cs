using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class MasterOfMind : SpellScriptBase
    {
        public override string Name { get { return "Mastery Of Mind"; } }
        public override string Description { get { return "You gain complete mastery over your mind, doubling your MD."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 72; } }
        public override double Delay { get { return .7; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.MD, 1);
        }
    }
}