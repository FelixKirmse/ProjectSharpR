using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IBattleModel
    {
        ITargetInfo TargetInfo { get; set; }
        ICharacter CurrentAttacker { get; set; }
        BattleState CurrentBattleState { get; set; }

        bool IsEnemyTurn { get; set; }

        int ExperienceEarned { get; set; }

        IBattleLog BattleLog { get; }
        IMobPack CurrentMobPack { get; }

        bool IsBossFight { get; }
        bool TargetIsEnemy { get; }
        bool AttackerIsEnemy { get; }

        int PlayerDeathCount { get; }
        int EnemyDeathCount { get; }
        int BattleLvl { get; }

        IList<ICharacter> Enemies { get; }
        IList<ICharacter> FrontRow { get; }
        IList<ICharacter> EnemyMinions { get; } 
        IList<ICharacter> PlayerMinions { get; }

        ICharacter CreateMinion(ICharacter template);
        ICharacter CreateEnemyMinion(ICharacter template);
        ICharacter CreatePlayerMinion(ICharacter template);
        
        void EndBattle();
        void EnemyDied();
        void PlayerDied();

        void RemoveEnemy(ICharacter enemy);
        void RemoveMinion(ICharacter minion);
        void StartBattle(IMobPack pack, int statBonus, bool doubleStatBonus);

        bool CharacterIsEnemy(ICharacter character);
    }
}