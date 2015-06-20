using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class MiniBlackHole : SpellScriptBase
    {
        public override string Name { get { return "Mini Black Hole"; } }
        public override string Description { get { return "Summon a mini black hole behind your enemies.\nReduces SPD."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.WND, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return .25; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = ((2.25 * cAD + 2.25 * cMD) * (cWND / 100) - (.75 * tDEF + .75 * tMR)) * (100 / tWND);
            BuffStat(Stat.SPD, -.4);
            DealDamage(damage);
        }
    }
}