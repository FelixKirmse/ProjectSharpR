using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SummonImp : SpellScriptBase
    {
        public override string Name { get { return "Summon: Imp"; } }
        public override string Description { get { return "Summons an Imp that casts damage spells."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster)
        {
            var minion = SummonMinionCopy(caster, "Imp");
            minion.Spells.Clear();
            AddSpell(minion, "Netherball");
            AddSpell(minion, "Netherball");
            AddSpell(minion, "Fire Wheel");
            AddSpell(minion, "Piercing Flames");
            AddSpell(minion, "Haunt");
        }
    }
}