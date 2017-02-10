using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class VengefulSpirit : SpellScriptBase
    {
        public override string Name { get { return "Vengeful Spirit"; } }
        public override string Description { get { return "Send out a spirit to attack your target.\nLowers DEF and can inflict PNS."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .32; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = ((2.625 * aAD + 2.625 * aMD) * (aHOL / 100) - (.875 * dDEF + .875 * dMR)) * (100 / dHOL);
            BuffStat(Stat.DEF, -.5);
            TryToApplyDebuff(DebuffResistance.PSN, 35);
            DealDamage(damage);
        }
    }
}