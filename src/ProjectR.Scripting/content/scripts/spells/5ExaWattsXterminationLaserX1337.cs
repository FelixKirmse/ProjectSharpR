using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class ExaWattsXterminationLaserX1337 : SpellScriptBase
    {
        public override string Name { get { return "5 ExaWatts Xtermination Laser X1337"; } }
        public override string Description { get { return "Oh god, what the shit is that thing?\nDon't point it in my direction, FUCK!"; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[0]; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            DealDamage(target, 10 * AD(caster) - .75 * DEF(target));
        }
    }
}