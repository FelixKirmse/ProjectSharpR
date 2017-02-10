using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class CripplingAura : SpellScriptBase
    {
        public override string Name { get { return "Crippling Aura"; } }
        public override string Description { get { return "Focus your aura to cripple your enemies.\nReduces AD, MD, DEF & MR of enemies."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 88; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.AD, -1);
            BuffStat(Stat.MD, -1);
            BuffStat(Stat.DEF, -1);
            BuffStat(Stat.MR, -1);
        }
    }
}