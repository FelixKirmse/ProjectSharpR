using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class HealingRain : SpellScriptBase
    {
        public override string Name { get { return "Healing Rain"; } }
        public override string Description { get { return "Summon a healing rain that provides good healing to your party."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 44; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var healing = 2.5 * cAD + 2.5 * cMD;
            Heal(healing);
        }
    }
}