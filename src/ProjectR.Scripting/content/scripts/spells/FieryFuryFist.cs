using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class FieryFuryFist : SpellScriptBase
    {
        public override string Name { get { return "Fiery Fury Fist"; } }
        public override string Description { get { return "Strike with your flame-imbued fist.\nThe heat causes you to ignore some of the enemies DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 58; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (5 * cMD * (cFIR / 100) - .8 * tMR) * (100 / tFIR);
            DealDamage(damage);
        }
    }
}