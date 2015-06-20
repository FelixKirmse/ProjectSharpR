﻿using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class SupportTechniqueWand : SpellScriptBase
    {
        public override string Name { get { return "Support Technique: Wand"; } }
        public override string Description { get { return "Increases MD of all allies."; } }

        public override TargetType TargetType { get { return TargetType.Allies; } }
        public override IList<EleMastery> Masteries { get { return new EleMastery[] { }; } }
        public override SpellType SpellType { get { return SpellType.Magical; } }
        public override bool IsSupportSpell { get { return false; } }

        public override double MPCost { get { return 80; } }
        public override double Delay { get { return .3; } }

        public override void SpellEffect(ICharacter caster, ICharacter target)
        {
            BuffStat(Stat.MD, .58);
        }
    }
}