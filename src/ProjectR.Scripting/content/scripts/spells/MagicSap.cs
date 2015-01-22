using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class MagicSap : SpellScriptBase
    {
        public override string Name { get { return "Magic Sap"; } }
        public override string Description { get { return "Sap the magic energy of your enemies.\nSlighty reduces enemies MD."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 48; } }
        public override double Delay { get { return .4; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 4.125 * cMD - 1.375 * tMR;
            BuffStat(Stat.MD, -.30);
            DealDamage(damage);
        }
    }
}