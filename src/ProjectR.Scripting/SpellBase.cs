using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public abstract class SpellBase : ISpell
    {
        protected ICharacter Caster { get; private set; }
        protected ICharacter Target { get; set; }
        public abstract TargetType TargetType { get; }
        public abstract string Description { get; }
        public abstract bool IsSupportSpell { get; }
        public abstract double Delay { get; }
        public abstract IList<EleMastery> Masteries { get; }
        public abstract SpellType SpellType { get; }
        public abstract double MPCost { get; }
        public abstract string Name { get; }

        public void Cast(ICharacter caster, IList<ICharacter> allies, IList<ICharacter> enemies)
        {
            Caster = caster;
            switch (TargetType)
            {
                case TargetType.Everyone:
                    SpellEffect(caster, allies, enemies);
                    break;
            }
        }

        public void Cast(ICharacter caster, IList<ICharacter> targets)
        {
            Caster = caster;
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
            Caster = caster;
            Target = target;

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

        public virtual void SpellEffect(ICharacter caster, ICharacter target)
        {
        }

        public virtual void SpellEffect(ICharacter caster, ICharacter target, double decayMod)
        {
        }

        public virtual void SpellEffect(ICharacter caster, IList<ICharacter> targets)
        {
            foreach (var target in targets)
            {
                Target = target;
                SpellEffect(caster, target);
            }
        }

        public virtual void SpellEffect(ICharacter caster)
        {
        }

        public virtual void SpellEffect(ICharacter caster, IList<ICharacter> allies, IList<ICharacter> enemies)
        {
        }
    }
}