using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SurgeOfLightning : SpellScriptBase
    {
        public override string Name { get { return "Surge of Lightning"; } }
        public override string Description { get { return "Infuse your target with the power of lightning.\nIncreases AD & MD greatly.\nInflicts PAR."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return 60; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.AD, 2);
            BuffStat(Stat.MD, 2);
            TryToApplyDebuff(DebuffResistance.PAR, 300);
        }
    }
}