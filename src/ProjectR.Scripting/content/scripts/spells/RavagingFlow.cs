using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class RavagingFlow : SpellScriptBase
    {
        public override string Name { get { return "Ravaging Flow"; } }
        public override string Description { get { return "Fires a concentrated laser of pure arcane engery at the target.\nUses up all of your MP, making the spell stronger.\nYou are completely exhausted after using this."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] {EleMastery.ARC,  }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 70; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damageMod = caster.CurrentMP / 10;
            var damage = ((8 + damageMod) * aMD * (aARC/100) - .5 * dMR) * (100/dARC);
            caster.UseMP(200);
            DealDamage(damage);
        }
    }
}