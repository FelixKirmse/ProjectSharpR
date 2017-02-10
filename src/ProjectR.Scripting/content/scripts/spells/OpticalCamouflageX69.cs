using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class OpticalCamouflageX69 : SpellScriptBase
    {
        public override string Name { get { return "Optical Camouflage X69"; } }
        public override string Description { get { return "Vanish before your foes.\nIncreases defensive stats, lolumad?"; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return 36; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.EVA, .66);
            BuffStat(Stat.DEF, .5);
            BuffStat(Stat.MR, .5);
            BuffStat(Stat.SPD, .5);
        }
    }
}