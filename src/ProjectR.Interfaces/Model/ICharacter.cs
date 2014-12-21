using System.Collections.Generic;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface ICharacter : ICharacterEvents
    {
        string Name { get; set; }
        string Race { get; set; }
        string Lore { get; set; }

        double TurnCounter { get; set; }
        double TimeToAction { get; set; }
        double CurrentHP { get; set; }

        bool IsSilenced { get; set; }
        bool IsMinion { get; set; }
        bool IsMarked { get; set; }

        IStats Stats { get; set; }
        IList<ISpell> Spells { get; set; }

        double CurrentMP { get; }
        double DamageTaken { get; }

        int Lvl { get; }

        bool IsDead { get; }
        bool WasHealed { get; }
        bool BlockedDamage { get; }
        bool DodgedAttack { get; }
        bool WasAfflicted { get; }
        bool TakesTurn { get; }

        string AfflictedBy { get; }

        ICharacter Clone();

        void TakeDamage(double value);
        void TakeTrueDamage(double value);
        void UseMP(double value);
        void Heal(double value);
        void SetLvl(int levels = 1);
        void LvlUp(int experience);
        void UpdateTurnCounter(bool invokeEvents = true);
        void ResetDamageTaken();
        void AddAffliction(string name);
        void BuffStat(int stat, float value);
        void TurnEnded();
    }
}