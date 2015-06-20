using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class HolyEntanglement : SpellScriptBase
    {
        public override string Name { get { return "Holy Entanglement"; } }
        public override string Description { get { return "A divine being prevents your enemies from evading.\nReduces enemies EVA."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 46; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.24 * cMD * (cHOL / 100) - .9 * tMR) * (100 / tHOL);
            BuffStat(Stat.EVA, -.5);
            DealDamage(damage);
        }
    }
}