using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Blitzkrieg : SpellScriptBase
    {
        public override string Name { get { return "Blitzkrieg"; } }
        public override string Description { get { return "Use the moment of surprise and increase SPD of all allies by 40%."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 122; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                BuffStat(target, Stat.SPD, .4d);
            }
        }
    }
}