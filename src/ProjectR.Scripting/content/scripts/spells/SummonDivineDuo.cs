using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SummonDivineDuo : SpellScriptBase
    {
        public override string Name { get { return "Summon: Divine Duo"; } }
        public override string Description { get { return "Summons Heel Yu and Boff Yu to aid your party."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            var minion = SummonMinionCopy(caster, "Boff Yu");
            minion.Spells.Clear();
            AddSpell(minion, "Inspire");
            AddSpell(minion, "Inspire");
            AddSpell(minion, "Blessing of the Gods");
            AddSpell(minion, "Blessing of the Wind God");
            AddSpell(minion, "Miracle Poke");
            AddSpell(minion, "Sharing is caring");
            AddSpell(minion, "Barrier of Faith");

            var minion2 = SummonMinionCopy(caster, "Heel Yu");
            minion2.Spells.Clear();
            AddSpell(minion2, "Healing Touch");
            AddSpell(minion2, "Healing Touch");
            AddSpell(minion2, "Healing Rain");
            AddSpell(minion2, "Blessed Ground");
            AddSpell(minion2, "Dark Fog (Ally)");
            AddSpell(minion2, "Dark Mend");
            AddSpell(minion2, "Divine Restoration");
            AddSpell(minion2, "Second Wind");
        }
    }
}