using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ForbiddenTechniqueRage : SpellScriptBase
    {
        public override string Name { get { return "Forbidden Technique: Rage"; } }
        public override string Description { get { return "Infuse your weapon with arcane and strike all enemies.\nDrops the wait gauge of allies by 15%% for each enemy hit."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = ((3 * cAD + 3 * cMD) * (cARC / 100) - (.75 * tDEF + .75 * tMR)) * (100 / tMR);
            DealDamage(damage);

            foreach (var character in GetCasterParty())
            {
                character.TurnCounter *= .85;
            }
        }
    }
}