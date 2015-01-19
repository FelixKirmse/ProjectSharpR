using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DivineRestoration : SpellScriptBase
    {
        public override string Name { get { return "Divine Restoration"; } }
        public override string Description { get { return "Heal and cleanse your target of all debuffs.\nHeal affected by HOL of both caster and target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var healing = cMD * (cHOL / tHOL);
            RemoveDebuffs();
            Heal(healing);
        }
    }
}