using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class FuckThemUp : SpellScriptBase
    {
        public override string Name { get { return "Fuck Them Up!"; } }
        public override string Description { get { return "Spread a deadly disease to your enemies.\nReduces EVA, DEF, MR & SPD.\nCan also inflict PAR, PSN and DTH."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (1.25 * cAD * (cDRK / 100) - 1.25 * tDEF) * (100 / tDRK);
            DealDamage(damage);

            TryToApplyDebuff(DebuffResistance.DTH, 30);
            TryToApplyDebuff(DebuffResistance.PSN, 45);
            TryToApplyDebuff(DebuffResistance.PAR, 30);

            BuffStat(Stat.EVA, -1.5);
            BuffStat(Stat.DEF, -.25);
            BuffStat(Stat.MR, -.25);
            BuffStat(Stat.SPD, -.25);
        }
    }
}