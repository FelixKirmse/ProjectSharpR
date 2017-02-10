using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Model
{
    public class BattleModel : IBattleModel
    {
        private readonly IModel _model;
        private BattleState _currentBattleState;

        public BattleModel(IModel model)
        {
            _model = model;
            BattleLog = new BattleLog(this);
            Enemies = new List<ICharacter>();
            EnemyMinions = new List<ICharacter>();
            PlayerMinions = new List<ICharacter>();
        }

        public ITargetInfo TargetInfo { get; set; }
        public ICharacter CurrentAttacker { get; set; }
        public bool IsEnemyTurn { get; set; }
        public int ExperienceEarned { get; set; }
        public IBattleLog BattleLog { get; private set; }
        public IMobPack CurrentMobPack { get; private set; }
        public bool IsBossFight { get; private set; }
        public int PlayerDeathCount { get; private set; }
        public int EnemyDeathCount { get; private set; }
        public int BattleLvl { get; private set; }
        public IList<ICharacter> Enemies { get; private set; }
        public IList<ICharacter> FrontRow { get; private set; }
        public IList<ICharacter> EnemyMinions { get; private set; }
        public IList<ICharacter> PlayerMinions { get; private set; }

        public bool TargetIsEnemy
        {
            get
            {
                return Enemies.Any(enemy => enemy == TargetInfo.Target) ||
                       EnemyMinions.Any(enemyMinion => enemyMinion == TargetInfo.Target);
            }
        }

        public bool AttackerIsEnemy
        {
            get { return Enemies.Any(x => x == CurrentAttacker) || EnemyMinions.Any(x => x == CurrentAttacker); }
        }

        public BattleState CurrentBattleState
        {
            get { return _currentBattleState; }
            set
            {
                if (value == BattleState.GameOver)
                {
                    value = BattleState.BattleWon;
                }

                _currentBattleState = value;
            }
        }

        public ICharacter CreateMinion(ICharacter template)
        {
            return CreateMinion(template, AttackerIsEnemy ? EnemyMinions : PlayerMinions);
        }

        public ICharacter CreateEnemyMinion(ICharacter template)
        {
            return CreateMinion(template, EnemyMinions);
        }

        public ICharacter CreatePlayerMinion(ICharacter template)
        {
            return CreateMinion(template, PlayerMinions);
        }

        public void EndBattle()
        {
            RHelper.ScriptHelper.ResetAllAfflictions();

            foreach (var character in Enemies)
            {
                _model.AfflictionFactory.GetAffliction(IsBossFight ? "Boss" : "Enemy").RemoveFrom(character);
            }
        }

        public void EnemyDied()
        {
            ++EnemyDeathCount;
        }

        public void PlayerDied()
        {
            ++PlayerDeathCount;
        }

        public void RemoveEnemy(ICharacter enemy)
        {
            Enemies.Remove(enemy);
        }

        public void RemoveMinion(ICharacter minion)
        {
            EnemyMinions.Remove(minion);
            PlayerMinions.Remove(minion);
        }

        public void StartBattle(IMobPack pack, Stat statBonus, bool doubleStatBonus)
        {
            CurrentMobPack = pack;
            CurrentBattleState = BattleState.Idle;
            BattleLvl = -1;
            IsBossFight = pack.Strength >= MobPackStrength.Boss;
            Enemies.Clear();
            EnemyMinions.Clear();
            PlayerMinions.Clear();
            FrontRow = _model.Party.FrontRow;
            EnemyDeathCount = 0;
            PlayerDeathCount = 0;
            BattleLog.ClearLog();
            GenerateEnemies(pack);
            Character.StaticTimeToAction = GetAvgSPD();
            SetInitialSpeed(Enemies);
            SetInitialSpeed(FrontRow);

            SetupPassives(Enemies, true);
            SetupPassives(EnemyMinions, true, true);
            SetupPassives(FrontRow);
            SetupPassives(_model.Party.BackSeat);

            SetStatBonus(Enemies, statBonus, doubleStatBonus);
            SetStatBonus(FrontRow, statBonus, doubleStatBonus);
            SetStatBonus(EnemyMinions, statBonus, doubleStatBonus);
            SetStatBonus(_model.Party.BackSeat, statBonus, doubleStatBonus);
        }

        public bool CharacterIsEnemy(ICharacter character)
        {
            return Enemies.Any(x => x == character) || EnemyMinions.Any(x => x == character);
        }

        private ICharacter CreateMinion(ICharacter minion, IList<ICharacter> minionList)
        {
            var specialChar = minion.Clone();
            specialChar.LvlUp(_model.Party.Experience);
            _model.AfflictionFactory.GetAffliction("Minion").AttachTo(specialChar);

            minionList.Insert(0, specialChar);
            if (minionList.Count != 3)
            {
                return specialChar;
            }

            minionList.RemoveAt(minionList.Count - 1);
            return specialChar;
        }

        private double GetAvgSPD()
        {
            var spdTotal = 0d;
            var charCount = 0;
            foreach (var enemy in Enemies)
            {
                spdTotal += enemy.Stats.GetTotalStat(BaseStat.SPD);
                ++charCount;
            }

            foreach (var character in FrontRow)
            {
                spdTotal += character.Stats.GetTotalStat(BaseStat.SPD);
                ++charCount;
            }

            foreach (var character in _model.Party.BackSeat)
            {
                spdTotal += character.Stats.GetTotalStat(BaseStat.SPD);
                ++charCount;
            }

            return spdTotal / charCount * 90d;
        }

        private static void SetInitialSpeed(IEnumerable<ICharacter> characters)
        {
            foreach (var character in characters)
            {
                character.TurnCounter = character.Stats[Stat.SPD][StatType.Base];
            }
        }

        private void SetupPassives(IEnumerable<ICharacter> list, bool enemy = false, bool minion = false)
        {
            foreach (var character in list)
            {
                foreach (var passive in _model.CharacterFactory.GetPassives(character))
                {
                    passive.AttachTo(character);
                }

                if (enemy)
                {
                    _model.AfflictionFactory.GetAffliction(IsBossFight ? "Boss" : "Enemy").AttachTo(character);
                }

                if (minion)
                {
                    _model.AfflictionFactory.GetAffliction("Minion").AttachTo(character);
                }

                character.Heal(character.Stats.GetTotalStat(BaseStat.HP));
                character.ResetDamageTaken();
            }
        }

        private static void SetStatBonus(IEnumerable<ICharacter> list, Stat stat, bool doubleBonus)
        {
            foreach (var character in list)
            {
                character.BuffStat(stat, .5d * (doubleBonus ? 2d : 1d));
                character.ResetDamageTaken();
            }
        }

        private void GenerateEnemies(IMobPack pack)
        {
            if (IsBossFight)
            {
                // TODO Parse Bossfile of Boss and attach behavior
                return;
            }

            var experience = _model.Party.Experience;

            foreach (var enemy in pack.Enemies)
            {
                var xpFactor = 1d;
                switch (pack.GetStrength(enemy))
                {
                    case MobPackStrength.Stronger:
                        xpFactor = 1.05d;
                        break;

                    case MobPackStrength.Challenging:
                        xpFactor = 1.1d;
                        break;

                    case MobPackStrength.Elite:
                        xpFactor = 1.2d;
                        break;

                    case MobPackStrength.Boss:
                        xpFactor = 1.5d;
                        break;

                    case MobPackStrength.EndBoss:
                        xpFactor = 3.0d;
                        break;

                    case MobPackStrength.TheEndOfAllThings:
                        xpFactor = 133.7d;
                        break;
                }

                enemy.LvlUp((int) (experience * xpFactor));
                Enemies.Add(enemy);
            }

            foreach (var minion in pack.Minions)
            {
                minion.LvlUp(experience);
                EnemyMinions.Add(minion);
            }
        }
    }
}