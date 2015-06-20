using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SummonChaosTroubleMakers : SpellScriptBase
    {
        public override string Name { get { return "Summon: Chaos Troublemakers"; } }
        public override string Description { get { return "Summons Statt and Daun to ruin your enemies day."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            var daun = SummonMinionCopy(caster, "Daun");
            daun.Spells.Clear();
            AddSpell(daun, "Sniff my finger!");
            AddSpell(daun, "Sniff my finger!");
            AddSpell(daun, "Freeze Them To Death!");
            AddSpell(daun, "Orb of Filth");
            AddSpell(daun, "Poison Flight");
            AddSpell(daun, "Shadow Trap");
            AddSpell(daun, "Timestop");

            var statt = SummonMinionCopy(caster, "Statt");
            statt.Spells.Clear();
            AddSpell(statt, "Sniff my finger!");
            AddSpell(statt, "Sniff my finger!");
            AddSpell(statt, "Cataclysmic Barrier");
            AddSpell(statt, "Chaos Barrier");
            AddSpell(statt, "Fuck Them Up!");
            AddSpell(statt, "Deadly Venom");
            AddSpell(statt, "Deadly Swarm");
        }
    }
}