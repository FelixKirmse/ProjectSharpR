using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Cleanse : SpellScriptBase
    {
        public override string Name { get { return "Cleanse"; } }
        public override string Description { get { return "Cleanses target of all status effects. Also provides slight healing."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 10; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            RemoveDebuffs();
            var healing = 1.5 * cAD + 1.5 * cMD;
            Heal(healing);
        }
    }
}