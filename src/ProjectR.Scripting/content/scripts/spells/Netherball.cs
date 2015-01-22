using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Netherball : SpellScriptBase
    {
        public override string Name { get { return "Netherball"; } }
        public override string Description { get { return "Shoot a weak Netherball at your enemies. Recovers some MP."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            DealDamage(cAD + cMD);
            caster.UseMP(-(cMP * .2));
        }
    }
}