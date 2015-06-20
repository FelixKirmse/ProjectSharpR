using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class FrozenBlood : SpellScriptBase
    {
        public override string Name { get { return "Frozen Blood"; } }
        public override string Description { get { return "Freeze your blood to enhance your defesive capabilities.\nAlso vastly increases ICE mastery."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 36; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.DEF, .5);
            BuffStat(Stat.MR, .5);
            BuffStat(Stat.ICE, 1);
        }
    }
}