using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class BlessingOfTheWindGod : SpellScriptBase
    {
        public override string Name { get { return "Blessing Of The Wind God"; } }
        public override string Description { get { return "Bless the target, enhancing defensive capabilities."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 12; } }
        public override double Delay { get { return .65; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.DEF, .5);
            BuffStat(Stat.MR, .5);
        }
    }
}