using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class DarkFogEnemy : SpellScriptBase
    {
        public override string Name { get { return "Dark Fog (Enemy)"; } }
        public override string Description { get { return "Summon a fog that deals unresistable DRK damage."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK, }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .38; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 2 * cMD * (cDRK / 100);
            DealDamage(damage);
        }
    }
}