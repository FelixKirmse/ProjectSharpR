using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class FuzzyOverhaul : SpellScriptBase
    {
        public override string Name { get { return "Fuzzy Overhaul"; } }
        public override string Description { get { return "Cleanse target from all stat buffs and debuffs."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            RemoveStatDebuffs();
            RemoveStatBuffs();
        }
    }
}