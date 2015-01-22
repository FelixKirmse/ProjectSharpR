using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class LingeringDeath : SpellScriptBase
    {
        public override string Name { get { return "Lingering Death"; } }
        public override string Description { get { return "Spread a deadly disease to your allies.\nReduces EVA, DEF, MR & SPD.\nCan also inflict PAR, PSN and DTH."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            TryToApplyDebuff(DebuffResistance.DTH, 30);
            TryToApplyDebuff(DebuffResistance.PSN, 45);
            TryToApplyDebuff(DebuffResistance.PAR, 30);

            BuffStat(Stat.EVA, -.25);
            BuffStat(Stat.DEF, -.25);
            BuffStat(Stat.MR, -.25);
            BuffStat(Stat.SPD, -.25);
        }
    }
}