using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class TimeStop : SpellScriptBase
    {
        public override string Name { get { return "Timestop"; } }
        public override string Description { get { return "Stop the time for your enemies.\nReduces SPD and is nearly guaranteed to inflict PAR."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Pure; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 60; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = .5 * aMD;
            DealDamage(damage);

            BuffStat(Stat.SPD, -1);
            TryToApplyDebuff(DebuffResistance.PAR, 120);
        }
    }
}