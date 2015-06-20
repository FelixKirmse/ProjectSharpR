using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SecretTechniqueStoneform : SpellScriptBase
    {
        public override string Name { get { return "Secret Technique: Stoneform"; } }
        public override string Description { get { return "Turn to stone. Increases DEF, MR & EVA.\nReduces SPD.\nInflicts PAR & SIL."; } }

        public override TargetType TargetType { get { return TargetType.Myself; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 128; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster)
        {
            BuffStat(Stat.DEF, 2);
            BuffStat(Stat.MR, 2);
            BuffStat(Stat.EVA, 2);
            BuffStat(Stat.SPD, -1);

            TryToApplyDebuff(DebuffResistance.PAR, 200);
            TryToApplyDebuff(DebuffResistance.SIL, 200);
        }
    }
}