using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ChaosCleanse : SpellScriptBase
    {
        public override string Name { get { return "Chaos Cleanse"; } }
        public override string Description { get { return "Summon a chaotic storm on the battlefield.\nDeals DRK damage to enemies.\nCleanses stat debuffs of allies."; } }

        public override TargetType TargetType { get { return TargetType.Everyone; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 96; } }
        public override double Delay { get { return .24; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> allies, IList<ICharacter> enemies)
        {
            foreach (var target in enemies)
            {
                Target = target;
                var damage = (3.75 * cMD * (cDRK / 100) - .625 * tMR) * (100 / tDRK);
                DealDamage(damage);
            }

            foreach (var target in allies)
            {
                Target = target;
                RemoveStatDebuffs();
            }
        }
    }
}