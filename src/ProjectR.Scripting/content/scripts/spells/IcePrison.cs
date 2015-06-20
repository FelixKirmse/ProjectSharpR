using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class IcePrison : SpellScriptBase
    {
        public override string Name { get { return "Ice Prison"; } }
        public override string Description { get { return "Imprison every enemy within ice.\nCan inflict PAR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.3 * cAD * (cICE / 100) - .825 * tDEF) * (100 / tICE);
            TryToApplyDebuff(DebuffResistance.PAR, 35);
            DealDamage(damage);
        }
    }
}