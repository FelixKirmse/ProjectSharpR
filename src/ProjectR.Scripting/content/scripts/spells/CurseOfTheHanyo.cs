using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class CurseOfTheHanyo : SpellScriptBase
    {
        public override string Name { get { return "Curse of the Han'yo"; } }
        public override string Description { get { return "Unleash your full demonic potential.\nIncreases AD, MD, DEF & MR.\nInflicts PSN & PAR."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 66; } }
        public override double Delay { get { return .6; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.AD, 2);
            BuffStat(Stat.MD, 2);
            BuffStat(Stat.DEF, 2);
            BuffStat(Stat.MR, 2);

            TryToApplyDebuff(DebuffResistance.PSN, 200);
            TryToApplyDebuff(DebuffResistance.PAR, 200);
        }
    }
}