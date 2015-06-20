using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class IcicleBarrage : SpellScriptBase
    {
        public override string Name { get { return "Icicle Barrage"; } }
        public override string Description { get { return "Summon icicles to impale your enemies.\nPierces MR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 30; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (2.5 * cMD * (cICE / 100) - .5 * tMR) * (100 / tICE);
            DealDamage(damage);
        }
    }
}