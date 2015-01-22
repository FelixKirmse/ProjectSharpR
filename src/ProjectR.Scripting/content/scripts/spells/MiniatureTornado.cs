using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class MiniatureTornado : SpellScriptBase
    {
        public override string Name { get { return "Miniature Tornado"; } }
        public override string Description { get { return "Summon a mini tornado among the enemy ranks.\nEnemies near the target also take damage.\nTargets enemy DEF."; } }

        public override TargetType TargetType { get { return TargetType.Decaying; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 64; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target, double modifier)
        {
            var damage = ((3.75 * cMD * (cWND / 100) - .75 * tDEF) * (100 / tWND)) / modifier;
            DealDamage(damage);
        }
    }
}