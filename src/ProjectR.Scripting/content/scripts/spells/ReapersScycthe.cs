using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ReapersScycthe : SpellScriptBase
    {
        public override string Name { get { return "Reaper's Scythe"; } }
        public override string Description { get { return "A deadly slash with your scythe.\nChance to instantly kill target.\nHeals for 100%% of damage done.\nCan't be evaded."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.DRK,  }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 0; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            TryToApplyDebuff(DebuffResistance.DTH, 30);
            var damage = aAD * (aDRK / dDRK);
            DealDamage(damage);
            Heal(caster, damage);
        }
    }
}