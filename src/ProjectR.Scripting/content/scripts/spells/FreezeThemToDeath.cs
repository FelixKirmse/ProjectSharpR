using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class FreezeThemToDeath : SpellScriptBase
    {
        public override string Name { get { return "Freeze Them To Death!"; } }
        public override string Description { get { return "Absorb all heat from your enemies bodies.\nChance to instantly kill targets."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.375 * cAD * (cICE / 100) - .875 * tDEF) * (100 / tICE);
            TryToApplyDebuff(DebuffResistance.DTH, 40);
            DealDamage(damage);
        }
    }
}