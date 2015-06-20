using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class BreathOfTheBabyIceDragon : SpellScriptBase
    {
        public override string Name { get { return "Breath of the Baby Ice Dragon"; } }
        public override string Description { get { return "A breath attack using both your AD & MD to slow your target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ICE,  }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 20; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (((2.53 * cAD + 2.53 * cMD) * (cICE/100)) - (.8 * tDEF + .8 * tMR)) * (100/tICE);

            BuffStat(Stat.SPD, -.5);

            DealDamage(damage);
        }
    }
}