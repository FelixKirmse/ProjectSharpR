using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SniffMyFinger : SpellScriptBase
    {
        public override string Name { get { return "Sniff my finger!"; } }
        public override string Description { get { return "You know exactly what this does. Reduces target DEF + MR and restores some MP."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.DEF, -.3);
            BuffStat(Stat.MR, -.3);
            caster.UseMP(-40);
        }
    }
}