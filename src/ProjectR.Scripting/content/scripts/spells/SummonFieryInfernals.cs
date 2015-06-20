using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SummonFieryInfernals : SpellScriptBase
    {
        public override string Name { get { return "Summon: Steam Duo"; } }
        public override string Description { get { return "Summons I.C. and Fiahr to overwhelm your enemies."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            var minion = SummonMinionCopy(caster, "Fiahr");
            minion.Spells.Clear();
            AddSpell(minion, "Netherball");
            AddSpell(minion, "Netherball");
            AddSpell(minion, "Extinction");
            AddSpell(minion, "Hellfire Flare");
            AddSpell(minion, "Hell's Inferno");
            AddSpell(minion, "Nuclear Meltdown");
            AddSpell(minion, "Ragnarok");

            var minion2 = SummonMinionCopy(caster, "I.C.");
            minion2.Spells.Clear();
            AddSpell(minion2, "Netherball");
            AddSpell(minion2, "Netherball");
            AddSpell(minion2, "Frost Blast");
            AddSpell(minion2, "Frozen Blood");
            AddSpell(minion2, "Ice Prison");
            AddSpell(minion2, "Icicle Barrage");
            AddSpell(minion2, "Breath of the Baby Ice Dragon");
        }
    }
}