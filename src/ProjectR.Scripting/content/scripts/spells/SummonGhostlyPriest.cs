using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SummonGhostlyPriest : SpellScriptBase
    {
        public override string Name { get { return "Summon: Ghostly Priest"; } }
        public override string Description { get { return "Summons a Ghostly Priest that casts support spells on your party."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster)
        {
            var minion = SummonMinionCopy(caster, "Ghostly Priest");
            minion.Spells.Clear();
            AddSpell(minion, "Healing Touch");
            AddSpell(minion, "Healing Touch");
            AddSpell(minion, "Cleanse");
            AddSpell(minion, "Blessed Ground");
            AddSpell(minion, "Sharing is caring");
        }
    }
}