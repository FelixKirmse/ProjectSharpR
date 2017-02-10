using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class DarknessComesFromWithin : SpellScriptBase
    {
        public override string Name { get { return "Darkness Comes From Within"; } }
        public override string Description { get { return "Unleash your inner darkness onto your enemies.\nRemoves caster's debuffs."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            RemoveDebuffs(caster);

            var damage = 3.125 * cMD * (cDRK / 100);
            DealDamage(damage);
        }
    }
}