using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class LetsSpeedThisUp : SpellScriptBase
    {
        public override string Name { get { return "Let's Speed This Up!"; } }
        public override string Description { get { return "Instantly fills the speed bar of your allies to 100%%."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            if (target != caster)
            {
                target.TurnCounter = target.TimeToAction;
            }
        }
    }
}