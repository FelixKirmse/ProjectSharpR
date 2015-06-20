using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class RagingFireStorm : SpellScriptBase
    {
        public override string Name { get { return "Raging Firestorm"; } }
        public override string Description { get { return "Summon a raging firestorm that engulfs all enemies.\nReduces enemies AD & MD."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.375 * cMD * ((cFIR + cWND) / 200) - 1.25 * tMR) * (200 / (tFIR + tWND));
            BuffStat(Stat.AD, -.22);
            BuffStat(Stat.MD, -.22);
            DealDamage(damage);
        }
    }
}