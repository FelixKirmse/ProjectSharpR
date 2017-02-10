using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class InspiringSpeech : SpellScriptBase
    {
        public override string Name { get { return "Inspiring Speech"; } }
        public override string Description { get { return "Hold an incredibly inspiring speech.\nIncreases AD, MD, DEF & MR significantly.\nUses up all your MP."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 188; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            caster.UseMP(cMP);
            BuffStat(Stat.AD, 2);
            BuffStat(Stat.MD, 2);
            BuffStat(Stat.DEF, 2);
            BuffStat(Stat.MR, 2);
        }
    }
}