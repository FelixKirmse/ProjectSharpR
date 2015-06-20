using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class SecondWind : SpellScriptBase
    {
        public override string Name { get { return "Second Wind"; } }
        public override string Description { get { return "Heal target with the power of the wind."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND,  }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 18; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var healing = 1.8 * aMD * (aWND / 100);
            Heal(healing);
        }
    }
}