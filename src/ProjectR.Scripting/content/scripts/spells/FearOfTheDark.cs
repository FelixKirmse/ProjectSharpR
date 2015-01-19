using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class FearOfTheDark : SpellScriptBase
    {
        public override string Name { get { return "Fear Of The Dark"; } }
        public override string Description { get { return "Darkness surrounds your enemies, driving them insane."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 30; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.24 * cMD * (cDRK / 100) - .9 * tMR) * (100 / tDRK);
            DealDamage(damage);
        }
    }
}