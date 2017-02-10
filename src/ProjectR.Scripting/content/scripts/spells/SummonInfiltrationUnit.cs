using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SummonInfiltrationUnit : SpellScriptBase
    {
        public override string Name { get { return "Summon: Infiltration Unit"; } }
        public override string Description { get { return "Summons Assa and Sin to wreak havoc among the enemies ranks."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            var minion = SummonMinionCopyAmongEnemy(caster, "Sin");
            minion.Spells.Clear();
            AddSpell(minion, "Backstab!");

            var minion2 = SummonMinionCopyAmongEnemy(caster, "Assa");
            minion2.Spells.Clear();
            AddSpell(minion2, "Backstab!");
        }
    }
}