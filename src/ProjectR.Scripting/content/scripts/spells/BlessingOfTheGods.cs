using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BlessingOfTheGods : SpellScriptBase
    {
        public override string Name { get { return "Blessing of the Gods"; } }
        public override string Description { get { return "Bless the target, increasing all their stats.\nAlso sets their speed bar to 100%%."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 132; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            target.TurnCounter = target.TimeToAction * .99;

            BuffAllStats(target, .25);
        }
    }
}