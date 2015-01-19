using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class HiddenPower : SpellScriptBase
    {
        public override string Name { get { return "Hidden Power"; } }
        public override string Description { get { return "Heighten your combat ability for speed.\nIncreases AD & DEF, decreases SPD."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 80; } }
        public override double Delay { get { return .8; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.AD, .75);
            BuffStat(Stat.DEF, .75);
            BuffStat(Stat.SPD, -.75);
        }
    }
}