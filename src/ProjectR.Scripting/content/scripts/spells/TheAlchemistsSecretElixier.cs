using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class TheAlchemistsSecretElixier : SpellScriptBase
    {
        public override string Name { get { return "The Alchemists Secret Elixir"; } }
        public override string Description { get { return "Chug down an elixir of great power.\nIncreases all your stats.\nLow delay."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 72; } }
        public override double Delay { get { return .84; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffAllStats(caster, .4);
        }
    }
}