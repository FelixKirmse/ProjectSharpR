using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Untouchable : SpellScriptBase
    {
        public override string Name { get { return "Untouchable"; } }
        public override string Description { get { return "Your concentration allows you to better react to incoming attacks.\nGreatly increases EVA."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 24; } }
        public override double Delay { get { return .66; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.EVA, 1);
        }
    }
}