using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class TwilightBarrier : SpellScriptBase
    {
        public override string Name { get { return "Twilight Barrier"; } }
        public override string Description { get { return "Summon a twilight barrier to aid your allies.\nIncreases DEF & MR."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.DEF, .5);
            BuffStat(Stat.MR, .5);
        }
    }
}