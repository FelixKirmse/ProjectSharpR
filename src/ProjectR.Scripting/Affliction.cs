using System;
using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public abstract class Affliction : IAffliction
    {
        public abstract string Name { get; }
        public abstract AfflictionType Type { get; }
        protected abstract HookPoint[] HookPoints { get; }

        private readonly HookPoint[] _hookPoints;
        private readonly Dictionary<ICharacter, bool> _afflictedChars = new Dictionary<ICharacter, bool>();

        private static IScriptHelper ScriptHelper { get { return RHelper.ScriptHelper; } }

        protected Affliction()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            _hookPoints = HookPoints;
        }

        public double GetVar(ICharacter character, string varName)
        {
            return ScriptHelper.GetVar(character, varName);
        }

        public void SetVar(ICharacter character, string varName, double value)
        {
            ScriptHelper.SetVar(character, varName, value);
        }

        public void AttachTo(ICharacter character)
        {
            var alreadyAttached = false;
            if (!_afflictedChars.ContainsKey(character))
            {
                _afflictedChars.Add(character, true);
            }
            else
            {
                alreadyAttached = true;
            }

            if (!alreadyAttached)
            {
                AttachEvents(character);
            }

            OnAttachment(character);
        }

        public void RemoveFrom(ICharacter character)
        {
            if (!_afflictedChars.ContainsKey(character))
            {
                return;
            }

            DetachEvents(character);
            ScriptHelper.RemoveAffliction(character, this);
            OnRemoval(character);
        }

        public void RemoveFromEveryone()
        {
            foreach (var afflictedChar in _afflictedChars.Keys)
            {
                RemoveFrom(afflictedChar);
            }
        }

        #region Attachment / Detachment
        private void DetachEvents(ICharacterEvents character)
        {
            foreach (var hookPoint in _hookPoints)
            {
                switch (hookPoint)
                {
                    case HookPoint.TakingDamage:
                        character.TakingDamage -= OnTakingDamage;
                        break;

                    case HookPoint.RollingEvasion:
                        character.RollingEvasion -= OnRollingEvasion;
                        break;

                    case HookPoint.AttackDodged:
                        character.AttackDodged -= OnAttackDodged;
                        break;

                    case HookPoint.AttackBlocked:
                        character.AttackBlocked -= OnAttackBlocked;
                        break;

                    case HookPoint.Dying:
                        character.Dying -= OnDying;
                        break;

                    case HookPoint.UsingMP:
                        character.UsingMP -= OnUsingMP;
                        break;

                    case HookPoint.Healing:
                        character.Healing -= OnHealing;
                        break;

                    case HookPoint.ApplyingBuff:
                        character.ApplyingBuff -= OnApplyingBuff;
                        break;

                    case HookPoint.ApplyingDebuff:
                        character.ApplyingDebuff -= OnApplyingDebuff;
                        break;

                    case HookPoint.BuffingStat:
                        character.BuffingStat -= OnBuffingStat;
                        break;

                    case HookPoint.RemovingDebuffs:
                        character.RemovingDebuffs -= OnRemovingDebuffs;
                        break;

                    case HookPoint.RemovingBuffs:
                        character.RemovingBuffs -= OnRemovingBuffs;
                        break;

                    case HookPoint.TurnCounterUpdating:
                        character.TurnCounterUpdating -= OnTurnCounterUpdating;
                        break;

                    case HookPoint.TurnTriggered:
                        character.TurnTriggered -= OnTurnTriggered;
                        break;

                    case HookPoint.TurnCounterUpdated:
                        character.TurnCounterUpdated -= OnTurnCounterUpdated;
                        break;

                    case HookPoint.Attacking:
                        character.Attacking -= OnAttacking;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void AttachEvents(ICharacterEvents character)
        {
            foreach (var hookPoint in _hookPoints)
            {
                switch (hookPoint)
                {
                    case HookPoint.TakingDamage:
                        character.TakingDamage += OnTakingDamage;
                        break;

                    case HookPoint.RollingEvasion:
                        character.RollingEvasion += OnRollingEvasion;
                        break;

                    case HookPoint.AttackDodged:
                        character.AttackDodged += OnAttackDodged;
                        break;

                    case HookPoint.AttackBlocked:
                        character.AttackBlocked += OnAttackBlocked;
                        break;

                    case HookPoint.Dying:
                        character.Dying += OnDying;
                        break;

                    case HookPoint.UsingMP:
                        character.UsingMP += OnUsingMP;
                        break;

                    case HookPoint.Healing:
                        character.Healing += OnHealing;
                        break;

                    case HookPoint.ApplyingBuff:
                        character.ApplyingBuff += OnApplyingBuff;
                        break;

                    case HookPoint.ApplyingDebuff:
                        character.ApplyingDebuff += OnApplyingDebuff;
                        break;

                    case HookPoint.BuffingStat:
                        character.BuffingStat += OnBuffingStat;
                        break;

                    case HookPoint.RemovingDebuffs:
                        character.RemovingDebuffs += OnRemovingDebuffs;
                        break;

                    case HookPoint.RemovingBuffs:
                        character.RemovingBuffs += OnRemovingBuffs;
                        break;

                    case HookPoint.TurnCounterUpdating:
                        character.TurnCounterUpdating += OnTurnCounterUpdating;
                        break;

                    case HookPoint.TurnTriggered:
                        character.TurnTriggered += OnTurnTriggered;
                        break;

                    case HookPoint.TurnCounterUpdated:
                        character.TurnCounterUpdated += OnTurnCounterUpdated;
                        break;

                    case HookPoint.Attacking:
                        character.Attacking += OnAttacking;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
#endregion

        #region Events

        protected virtual void OnAttachment(ICharacter character)
        {
        }

        protected virtual void OnRemoval(ICharacter character)
        {
        }

        protected virtual void OnRemovingDebuffs(ICharacter character)
        {
        }

        protected virtual void OnRemovingBuffs(ICharacter character)
        {
        }

        protected virtual void OnTurnCounterUpdating(ICharacter character, BoolConsolidator result)
        {
        }

        protected virtual void OnTurnTriggered(ICharacter character)
        {
        }

        protected virtual void OnTurnCounterUpdated(ICharacter character)
        {
        }

        protected virtual void OnDying(ICharacter character)
        {
        }

        protected virtual void OnAttackDodged(ICharacter character, double damage)
        {
        }

        protected virtual void OnTakingDamage(ICharacter character, ref double damage)
        {
        }

        protected virtual void OnRollingEvasion(ICharacter character, ref double evaChance)
        {
        }

        protected virtual void OnAttackBlocked(ICharacter character, ref double damage, ref double reduction)
        {
        }

        protected virtual void OnUsingMP(ICharacter character, ref double value)
        {
        }

        protected virtual void OnHealing(ICharacter character, ref double healing)
        {
        }

        protected virtual void OnApplyingDebuff(ICharacter character, BoolConsolidator result)
        {
        }

        protected virtual void OnApplyingBuff(ICharacter character, BoolConsolidator result)
        {
        }

        protected virtual void OnBuffingStat(ICharacter character, ref Stat stat, ref double value)
        {
        }

        protected virtual void OnAttacking(ICharacter attacker, ICharacter target, ISpell spell, ref double damage,
                                ref double modifier)
        {
        }
        #endregion
    }
}