using System;
using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public abstract class SpellBase : ISpell
    {
        public abstract TargetType TargetType { get; }
        public abstract string Description { get; }
        public abstract bool IsSupportSpell { get; }
        public abstract double Delay { get; }
        public abstract IList<EleMastery> Masteries { get; }
        public abstract SpellType SpellType { get; }
        public abstract double MPCost { get; }
        public abstract string Name { get; }

        public void Cast(ICharacter caster, IList<ICharacter> targets)
        {
            switch (TargetType)
            {
                case TargetType.Allies:
                case TargetType.Enemies:
                    SpellEffect(caster, targets);
                    break;
            }
        }

        public void Cast(ICharacter caster, ICharacter target, double decayMod = 1d)
        {
            switch (TargetType)
            {
                case TargetType.Single:
                    SpellEffect(caster, target);
                    break;

                case TargetType.Myself:
                    SpellEffect(caster);
                    break;

                case TargetType.Decaying:
                    SpellEffect(caster, target, decayMod);
                    break;
            }
        }

        public virtual void SpellEffect(ICharacter caster, ICharacter target, double decayMod = 1d)
        {
        }

        public virtual void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
        }

        public virtual void SpellEffect(ICharacter caster)
        {
        }
    }
}