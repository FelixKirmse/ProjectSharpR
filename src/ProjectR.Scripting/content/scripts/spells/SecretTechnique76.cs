using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SecretTechnique76 : SpellScriptBase
    {
        public override string Name { get { return "Secret Technique #76"; } }
        public override string Description { get { return "A vicious strike that attempts to weaken the enemy.\nChance to steal stat buffs from target."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 76; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = (3.75 * aAD * (aARC / 100) - 1.25 * dDEF) * (100 / dARC);
            DealDamage(damage);
            for (var i = Stat.HP; i <= Stat.SIL; ++i)
            {
                var stat = target.Stats[i];
                var battleMod = stat[StatType.BattleMod];
                if (battleMod > 1 && RHelper.RollPercentage(40))
                {
                    BuffStat(caster, i, battleMod - 1);
                    stat[StatType.BattleMod] = 1;
                }
            }
        }
    }
}