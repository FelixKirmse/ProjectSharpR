using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class CleansingSong : SpellScriptBase
    {
        public override string Name { get { return "Cleansing Song"; } }
        public override string Description { get { return "Sing a nice melody that removes all status debuffs of the target\nand converts stat debuffs into buffs."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 40; } }
        public override double Delay { get { return .65; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            RemoveDebuffs();
            for (var stat = Stat.HP; stat < Stat.Count; ++ stat)
            {
                var battleMod = target.Stats[stat][StatType.BattleMod];
                if (battleMod < 1)
                {
                    BuffStat(stat, 1 - battleMod);
                }
            }
        }
    }
}