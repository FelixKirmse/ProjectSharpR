using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class DivineLightOfTheGoddess : SpellScriptBase
    {
        public override string Name { get { return "Divine Light of the Goddess"; } }
        public override string Description { get { return "Smite your enemies with this divine attack.\nVery high delay."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.HOL, }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 158; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 6.25 * cMD * (cHOL / 100);
            DealDamage(damage);
        }
    }
}