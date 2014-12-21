using System;
using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Model
{
    public class Character : ICharacter
    {
        #region Events
        public event CharacterTakingDamageDelegate TakingDamage = delegate { }; 
        public event CharacterRollingEvasionDelegate RollingEvasion = delegate { }; 
        public event CharacterDodgedAttackDelegate AttackDodged = delegate { }; 
        public event CharacterBlockedAttackDelegate AttackBlocked = delegate { }; 
        public event CharacterEventDelegate Dying = delegate { }; 
        public event CharacterUsingMPDelegate UsingMP = delegate { }; 
        public event CharacterHealingDelegate Healing = delegate { }; 
        public event CharacterBuffingStatDelegate BuffingStat = delegate { }; 
        public event CharacterEventDelegate RemovingDebuffs = delegate { }; 
        public event CharacterEventDelegate RemovingBuffs = delegate { }; 
        public event CharacterEventDelegate TurnTriggered = delegate { }; 
        public event CharacterEventDelegate TurnCounterUpdated = delegate { }; 
        public event CharacterAttackingDelegate Attacking = delegate { }; 
        public event CharacterBooleanEventDelegate ApplyingDebuff = delegate { }; 
        public event CharacterBooleanEventDelegate ApplyingBuff = delegate { }; 
        public event CharacterBooleanEventDelegate TurnCounterUpdating = delegate { }; 
        #endregion

        public const int XPRequiredForLvlUp = 2000;

        public string Name { get; set; }
        public string Race { get; set; }
        public string Lore { get; set; }
        public double TurnCounter { get; set; }
        public double TimeToAction { get; set; }
        public double CurrentHP { get; set; }
        public bool IsSilenced { get; set; }
        public bool IsMinion { get; set; }
        public bool IsMarked { get; set; }
        public IList<ISpell> Spells { get; set; }
        public double CurrentMP { get; private set; }
        public double DamageTaken { get; private set; }
        public int CurrentLevel { get; private set; }
        public bool IsDead { get { return CurrentHP < 1d; } }
        public bool WasHealed { get; private set; }
        public bool BlockedDamage { get; private set; }
        public bool DodgedAttack { get; private set; }
        public bool WasAfflicted { get { return AfflictedBy != ""; } }
        public bool TakesTurn { get; private set; }
        public string AfflictedBy { get; private set; }

        public IStats Stats
        {
            get { return _stats; }
            set
            {
                _stats = value;
                CurrentHP = _stats.GetTotalStat(Stat.HP);
                CurrentMP = _stats.GetTotalStat(Stat.MP);
            }
        }

        private IStats _stats;


        public Character(string name)
        {
            Name = name;
        }

        public ICharacter Clone()
        {
            var clone = new Character(Name)
            {
                Lore = Lore,
                Race = Race,
                Spells = Spells,
                Stats = Stats.Clone(),
                CurrentLevel = CurrentLevel
            };

            return clone;
        }

        public void TakeDamage(double value)
        {
            if (value <= 0d)
            {
                return;
            }

            var evaChance = _stats.GetEVAChance(CurrentLevel);
            RollingEvasion(this, ref evaChance);

            var attackEvaded = RHelper.RollPercentage((int) evaChance);
            if (attackEvaded && _stats.EVAType == EVAType.Dodge)
            {
                AttackDodged(this, value);
                DodgedAttack = true;
                return;
            }
            BlockedDamage = attackEvaded;

            var reduction = attackEvaded ? 2d : 1d;
            if (attackEvaded)
            {
                AttackBlocked(this, ref value, ref reduction);
            }

            value /= reduction;
            TakeTrueDamage(value);
        }

        public void TakeTrueDamage(double value)
        {
            if (value <= 0d)
            {
                return;
            }

            TakingDamage(this, ref value);
            DamageTaken += value;
            CurrentHP -= value;

            if (CurrentHP <= 1d)
            {
                Dying(this);
            }

            CurrentHP = Math.Max(0d, CurrentHP);
        }

        public void UseMP(double value)
        {
            UsingMP(this, ref value);

            CurrentMP -= value;
            CurrentMP = CurrentMP.Clamp(0d, 200d);
        }

        public void Heal(double value)
        {
            Healing(this, ref value);
            WasHealed = true;
            DamageTaken += value;
            CurrentHP += value;
            CurrentHP = Math.Min(CurrentHP, _stats.GetTotalStat(Stat.HP));
        }

        public void SetLvl(int newLevel = 1)
        {
            if (newLevel <= CurrentLevel)
            {
                return;
            }

            CurrentLevel = newLevel;

            if (Stats == null)
            {
                return;
            }

            Stats.SetLvl(CurrentLevel);
            CurrentHP = _stats.GetTotalStat(Stat.HP);
            CurrentHP = _stats.GetTotalStat(Stat.MP);
        }

        public void LvlUp(int experience)
        {
            if (IsDead)
            {
                return;
            }

            var newLevel = GetLevelFromExperience(experience);
            SetLvl(newLevel);
            ResetDamageTaken();
        }

        private int GetLevelFromExperience(double xp)
        {
            return (int) (1 + xp / (XPRequiredForLvlUp * _stats.XPMultiplier *
                                    (0.01 + 0.989 * Math.Pow(Math.E, -Math.Pow(10, -11) * Math.Pow(xp, 2)))));
        }

        public bool UpdateTurnCounter(bool invokeEvents = true)
        {
            if (IsDead)
            {
                return false;
            }

            var timeStep = _stats.GetTotalStat(Stat.SPD);
            if (invokeEvents)
            {
                var eventResult = new BoolConsolidator();
                TurnCounterUpdating(this, eventResult);
                if (!eventResult.Result())
                {
                    return false;
                }
            }

            var result = false;
            TurnCounter += timeStep;

            if (TurnCounter >= TimeToAction)
            {
                UseMP(-10d);
                TurnCounter -= TimeToAction;
                result = true;
                _stats.ReduceBuffEffectiveness();
                if (invokeEvents)
                {
                    TurnTriggered(this);
                }
                ResetDamageTaken();
            }

            if (invokeEvents)
            {
                TurnCounterUpdated(this);
            }

            TakesTurn = result;
            return result;
        }

        public void ResetDamageTaken()
        {
            DamageTaken = 0d;
            WasHealed = false;
            BlockedDamage = false;
            DodgedAttack = false;
            AfflictedBy = "";
        }

        public void AddAffliction(string name)
        {
            if (AfflictedBy == "")
            {
                AfflictedBy = name;
            }
            else
            {
                AfflictedBy += string.Format(", {0}", name);
            }
        }

        public void BuffStat(Stat stat, double value)
        {
            BuffingStat(this, ref stat, ref value);

            const string format = "{0} {1}";
            var add = string.Format(format, (value * 100d).ToString("P0"), stat.GetString());
            AddAffliction(add);
            _stats.BuffStat(stat, value);
        }

        public void TurnEnded()
        {
            TakesTurn = false;
        }
    }
}