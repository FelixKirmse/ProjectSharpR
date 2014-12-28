using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class BarrierOfFaith : SpellScriptBase
    {
        public override string Name { get { return "Barrier Of Faith"; } }
        public override string Description { get { return "Holy power flows through everyone in your party.\nIncreases DEF and MR."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                BuffStat(target, Stat.DEF, .5);
                BuffStat(target, Stat.MR, .5);
            }
        }
    }
}