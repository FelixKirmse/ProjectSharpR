using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class DarkFogAlly : SpellScriptBase
    {
        public override string Name { get { return "Dark Fog (Allies)"; } }
        public override string Description { get { return "Summon a fog that removes all debuffs and heals a little."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK,}; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 36; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            RemoveDebuffs();
            RemoveStatDebuffs();

            var healing = .25 * cMD * (cDRK / 100);
            Heal(healing);
        }
    }
}