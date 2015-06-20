using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BlessedGround : SpellScriptBase
    {
        public override string Name { get { return "Blessed Ground"; } }
        public override string Description { get { return "The ground below you becomes filled with holy energy.\nThe healing is not much, but the thought counts.\nYou are pretty tired after this spell."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 72; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                Target = target;
                Heal(target, .88 * cMD * (cHOL/tHOL));
            }
        }
    }
}