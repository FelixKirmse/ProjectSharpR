using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class OneAtATime : SpellScriptBase
    {
        public override string Name { get { return "One At A Time"; } }
        public override string Description { get { return "Focus your attacks on one enemy.\nHigh Delay."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 80; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (10 * cAD * (cWND / 100) - .8 * tDEF) * (100 / tWND);
            DealDamage(damage);
        }
    }
}