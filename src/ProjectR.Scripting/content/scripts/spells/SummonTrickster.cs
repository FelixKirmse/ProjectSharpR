using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SummonTrickster : SpellScriptBase
    {
        public override string Name { get { return "Summon: Trickster"; } }
        public override string Description { get { return "Summons a Trickster that debuffs enemies."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 100; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var minion = SummonMinionCopy(caster, "Trickster");
            minion.Spells.Clear();
            AddSpell(minion, "Sniff my finger!");
            AddSpell(minion, "Sniff my finger!");
            AddSpell(minion, "Crippling Aura");
            AddSpell(minion, "Poison Flight");
            AddSpell(minion, "Stun Bomb");
        }
    }
}