﻿using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class OffenseOfTheAncients : SpellScriptBase
    {
        public override string Name { get { return "Offense Of The Ancients"; } }
        public override string Description { get { return "An old and long forgotten spell.\nBuffs the offense of everyone in your Party,\nincluding characters on reserve."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return true; } }

        public override double MPCost { get { return 112; } }
        public override double Delay { get { return .35; } }

        public override void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            base.SpellEffect(caster, targets);

            foreach (var target in GetCasterReserveParty())
            {
                Target = target;
                SpellEffect(caster, target);
            }
        }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.AD, .3);
            BuffStat(Stat.MD, .3);
        }
    }
}