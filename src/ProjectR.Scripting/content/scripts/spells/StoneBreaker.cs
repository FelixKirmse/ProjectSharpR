﻿using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Spells
{
    public class StoneBreaker : SpellScriptBase
    {
        public override string Name { get { return "Stonebreaker"; } }
        public override string Description { get { return "A harsh kick that ignores a bunch of DEF."; } }

        public override TargetType TargetType { get { return TargetType.Single; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Physical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return .2; } }
        public override double Delay { get { return .5; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            var damage = 4.5 * aAD - .5 * dDEF;
            DealDamage(damage);
        }
    }
}