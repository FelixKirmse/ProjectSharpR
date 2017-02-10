using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Afflictions
{
    public class WindFury : Affliction
    {
        public override string Name { get { return "Windfury"; } }

        public override AfflictionType Type { get { return AfflictionType.Passive; } }

        protected override HookPoint[] HookPoints
        {
            get
            {
                return new[]
                {
                    HookPoint.Attacking, 
                };
            }
        }

        protected override void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage, ref double modifier)
        {
            if (spell.SpellType == SpellType.Physical && RollPercentage(2))
            {
                var windfurySpell = new WindfurySpell(spell);
                windfurySpell.Cast(attacker, target, modifier);
                windfurySpell.Cast(attacker, target, modifier);
            }
        }

        private class WindfurySpell : SpellScriptBase
        {
            private readonly ISpell _orgSpell;

            public WindfurySpell(ISpell orgSpell)
            {
                _orgSpell = orgSpell;
            }

            public override TargetType TargetType { get { return TargetType.Single; } }

            public override string Description { get { return _orgSpell.Description; } }

            public override bool IsSupportSpell { get { return _orgSpell.IsSupportSpell; } }

            public override double Delay { get { return _orgSpell.Delay; } }

            public override IList<EleMastery> Masteries { get { return _orgSpell.Masteries; } }

            public override SpellType SpellType { get { return _orgSpell.SpellType; } }

            public override double MPCost { get { return 0; } }

            public override string Name { get { return string.Format("{0} (Windfury)", _orgSpell.Name); } }
        }
    }
}