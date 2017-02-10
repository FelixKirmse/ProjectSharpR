using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class Ragnarok : SpellScriptBase
    {
        public override string Name { get { return "Ragnarok"; } }
        public override string Description { get { return "Fires a concentrated laser of pure arcane energy at your enemies.\nUses up all of your MP, making the spell stronger.\nYou are completely exhausted after using this."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.ARC, }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 160; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            var damageMod = caster.CurrentMP / 10;
            foreach (var target in targets)
            {
                Target = target;
                SpellEffect(caster, target, damageMod);
            }
            caster.UseMP(200);
        }

        public override void SpellEffect(ICharacter caster, ICharacter target, double damageMod)
        {
            var damage = ((8 + damageMod) * aMD * (aARC / 100) - .5 * dMR) * (100 / dARC);
            DealDamage(damage);
        }
    }
}