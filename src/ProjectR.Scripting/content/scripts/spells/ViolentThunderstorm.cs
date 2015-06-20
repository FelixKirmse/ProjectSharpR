using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ViolentThunderstorm : SpellScriptBase
    {
        public override string Name { get { return "Violent Thunderstorm"; } }
        public override string Description { get { return "Summon a violent thunderstorm to annihilate your foes.\nMelts the armor of each target hit."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .38; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.8 * aMD * (aWND / 100) - .95 * dMR) * (100 / dWND);
            DealDamage(damage);
        }
    }
}