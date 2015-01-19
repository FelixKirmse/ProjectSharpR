using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Hurricane : SpellScriptBase
    {
        public override string Name { get { return "Hurricane"; } }
        public override string Description { get { return "Summon a hurricane to blast away your enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .28; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (4.375 * cMD * (cWND / 100) - .875 * tMR) * (100 / tWND);
            DealDamage(damage);
        }
    }
}