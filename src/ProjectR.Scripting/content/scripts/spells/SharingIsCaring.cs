using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SharingIsCaring : SpellScriptBase
    {
        public override string Name { get { return "Sharing is caring"; } }
        public override string Description { get { return "Imbue your target with the power of the wind.\nLow delay.\nIncreases SPD."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 28; } }
        public override double Delay { get { return .75; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.SPD, .5);
        }
    }
}