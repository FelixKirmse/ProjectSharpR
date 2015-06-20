using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ForbiddenSpell64 : SpellScriptBase
    {
        public override string Name { get { return "Forbidden Spell #64"; } }
        public override string Description { get { return "Summons an explosion of unfathomable energy\nat target's location. Enemies in proximity\nof target also take reduced damage."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, EleMastery.WND, EleMastery.DRK,  }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 160; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double modifier)
        {
            var damage = (4.375 * cMD * ((cFIR + cWND + cDRK) / 100) - 1.75 * tMR) / modifier;
            DealDamage(damage);
        }
    }
}