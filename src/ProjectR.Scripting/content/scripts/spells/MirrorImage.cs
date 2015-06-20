using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class MirrorImage : SpellScriptBase
    {
        public override string Name { get { return "Mirror Image"; } }
        public override string Description { get { return "Creates two clones of the target to fight by your side. Clones use the same spells as the target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            SummonMinionCopy(target, "Mirror Image");
            SummonMinionCopy(target, "Mirror Image");
        }
    }
}