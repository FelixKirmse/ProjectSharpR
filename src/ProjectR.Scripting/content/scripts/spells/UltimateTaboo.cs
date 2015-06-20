using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class UltimateTaboo : SpellScriptBase
    {
        public override string Name { get { return "Ultimate Taboo"; } }
        public override string Description { get { return "Drain energy from your allies to empower your strike.\nExhausts all allies and turns 10%% of their HP into extra damage."; } }

        public override TargetType TargetType { get { return TargetType.Enemies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { EleMastery.FIR, }; } }
        public override SpellType SpellType { get { return SpellType.Composite; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 200; } }
        public override double Delay { get { return 0; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            var extraDamage = 0d;
            foreach (var character in GetCasterParty())
            {
                character.TurnCounter = 0;
                var extraValue = HP(character) * .1;
                extraDamage += extraValue;
                DealDamage(character, extraValue);
            }

            foreach (var target in targets)
            {
                Target = target;
                var damage = ((4.5 * aAD + 4.5 * aMD) * (aFIR / 100) - (.75 * dDEF + .75 * dMR)) * (100 / dFIR) + extraDamage;
                DealDamage(damage);
            }
        }
    }
}