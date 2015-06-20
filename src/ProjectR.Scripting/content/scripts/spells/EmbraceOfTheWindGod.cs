using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class EmbraceOfTheWindGod : SpellScriptBase
    {
        public override string Name { get { return "Embrace of the Wind God"; } }
        public override string Description { get { return "Strike your target with an empowered Wind Strike.\nIncreases your SPD."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 70; } }
        public override double Delay { get { return .7; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.75 * cAD * (cWND / 100) - 1.25 * tDEF) * (100 / tWND);
            BuffStat(caster, Stat.SPD, .3);
            DealDamage(damage);
        }
    }
}