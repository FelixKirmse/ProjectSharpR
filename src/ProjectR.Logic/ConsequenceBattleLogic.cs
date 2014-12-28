using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class ConsequenceBattleLogic : LogicState
    {
        private IBattleModel _battleModel;
        private ICharacter _currentAttacker;
        private ITargetInfo _targetInfo;
        private bool _enemyTurn;
        private int _frameCounter;
        private const int ConsequenceFrames = 90;
        private readonly double[] _charHPShouldHave = new double[4];
        private readonly double[] _charHPStep = new double[4];

        private readonly double[] _enemyHPShouldHave = new double[4];
        private readonly double[] _enemyHPStep = new double[4];

        public override void Run()
        {
            _battleModel = Model.BattleModel;
            _currentAttacker = _battleModel.CurrentAttacker;
            _targetInfo = _battleModel.TargetInfo;
            _enemyTurn = _battleModel.IsEnemyTurn;
            ++_frameCounter;

            if (_frameCounter == ConsequenceFrames)
            {
                FrameLimitReached();
                return;
            }

            if (_frameCounter > 1)
            {
                FramesCounting();
                return;
            }

            Calculate();
        }

        private void Calculate()
        {
            _currentAttacker.UseMP(_targetInfo.Spell.MPCost);
            _currentAttacker.TurnCounter = _currentAttacker.TimeToAction * _targetInfo.Spell.Delay;
            var targetIsEnemy = _battleModel.TargetIsEnemy;
            if (!targetIsEnemy)
            {
                Model.Statistics.AddToStatistic(Statistic.SpellsCast, 1);
            }

            var charHPBefore = new double[4];
            var enemyHPBefore = new double[4];

            var frontRow = _battleModel.FrontRow;
            var enemies = _battleModel.Enemies;
            var log = _battleModel.BattleLog;
            for (var i = 0; i < frontRow.Count; ++i)
            {
                charHPBefore[i] = frontRow[i].CurrentHP;
            }

            for (var i = 0; i < enemies.Count; ++i)
            {
                enemyHPBefore[i] = enemies[i].CurrentHP;
            }

            var spell = _targetInfo.Spell;
            var targetType = spell.TargetType;

            switch (targetType)
            {
                case TargetType.Single:
                    spell.Cast(_currentAttacker, _targetInfo.Target);
                    ResolveDamage(_targetInfo.Target);
                    ResolveDamage(_currentAttacker);
                    log.LogAction(_currentAttacker, _targetInfo.Target, _targetInfo.Spell);
                    _targetInfo.Target.IsMarked = true;
                    break;

                case TargetType.Myself:
                    spell.Cast(_currentAttacker, _currentAttacker);
                    ResolveDamage(_currentAttacker);
                    log.LogAction(_currentAttacker, _currentAttacker, _targetInfo.Spell);
                    break;

                case TargetType.Allies:
                case TargetType.Enemies:
                {
                    var attackerIsEnemy = _battleModel.AttackerIsEnemy;
                    var targetIsPlayer = (attackerIsEnemy && targetType != TargetType.Allies) ||
                                         (!attackerIsEnemy && targetType == TargetType.Allies);
                    var targetRow = targetIsPlayer ? frontRow : enemies;
                    spell.Cast(_currentAttacker, targetRow);

                    foreach (var character in targetRow)
                    {
                        ResolveDamage(character);
                        log.LogAction(_currentAttacker, character, _targetInfo.Spell);
                        character.IsMarked = true;
                    }
                    ResolveDamage(_currentAttacker);
                    break;
                }

                case TargetType.Decaying:
                {
                    spell.Cast(_currentAttacker, _targetInfo.Target);
                    ResolveDamage(_targetInfo.Target);
                    log.LogAction(_currentAttacker, _targetInfo.Target, _targetInfo.Spell);
                    _targetInfo.Target.IsMarked = true;

                    var targetRow = targetIsEnemy ? enemies : frontRow;
                    var casterRow = _enemyTurn ? frontRow : enemies;

                    var targetIndex = 0;
                    for (;targetIndex < targetRow.Count && 
                        casterRow[targetIndex] != _targetInfo.Target;
                        ++targetIndex)
                    {
                    }

                    for (int i = targetIndex - 1, mod = 2; i >= 0; --i, ++mod)
                    {
                        spell.Cast(_currentAttacker, targetRow[i], mod);
                        ResolveDamage(targetRow[i], mod);
                        log.LogAction(_currentAttacker, targetRow[i], _targetInfo.Spell);
                        targetRow[i].IsMarked = true;
                    }

                    for (int i = targetIndex + 1, mod = 2; i < targetRow.Count; ++i, ++mod)
                    {
                        spell.Cast(_currentAttacker, targetRow[i], mod);
                        ResolveDamage(targetRow[i], mod);
                        log.LogAction(_currentAttacker, targetRow[i], _targetInfo.Spell);
                        targetRow[i].IsMarked = true;
                    }

                    break;
                }
            }

            _enemyTurn = false;

            for (var i = 0; i < frontRow.Count; ++i)
            {
                var currentHP = frontRow[i].CurrentHP;
                _charHPShouldHave[i] = currentHP;
                _charHPStep[i] = (charHPBefore[i] - currentHP) / ConsequenceFrames;
                frontRow[i].CurrentHP = charHPBefore[i] - _charHPStep[i];
            }

            for (var i = 0; i < enemies.Count; ++i)
            {
                var currentHP = enemies[i].CurrentHP;
                _enemyHPShouldHave[i] = currentHP;
                _enemyHPStep[i] = (enemyHPBefore[i] - currentHP) / ConsequenceFrames;
                enemies[i].CurrentHP = enemyHPBefore[i] - _enemyHPStep[i];
            }

            var statistics = Model.Statistics;
            foreach (var character in frontRow)
            {
                statistics.AddToStatistic(character.WasHealed ? Statistic.HealingTaken : Statistic.DamageTaken, (uint) character.DamageTaken);

                if (character.DodgedAttack)
                {
                    statistics.AddToStatistic(Statistic.SuccessfulDodges, 1);
                }

                if (character.BlockedDamage)
                {
                    statistics.AddToStatistic(Statistic.DamageBlocked, (uint) character.DamageTaken);
                }
            }

            foreach (var character in enemies)
            {
                statistics.AddToStatistic(Statistic.DamageDone, (uint) character.DamageTaken);
            }
        }

        private void ResolveDamage(ICharacter target, double mod = 1d)
        {
            var damage = RHelper.ScriptHelper.GetDamageTaken(target);
            _currentAttacker.FireAttackingEvent(_currentAttacker, target, _targetInfo.Spell, ref damage, ref mod);

            if (damage < 0d)
            {
                target.Heal(-damage);
            }
            else if (_targetInfo.Spell.SpellType == SpellType.Pure)
            {
                target.TakeTrueDamage(damage);
            }
            else
            {
                target.TakeDamage(damage);
            }
        }

        private void FramesCounting()
        {
            var frontRow = _battleModel.FrontRow;
            for (var i = 0; i < frontRow.Count; ++i)
            {
                frontRow[i].CurrentHP = frontRow[i].CurrentHP - _charHPStep[i];
            }

            var enemies = _battleModel.Enemies;
            for (var i = 0; i < enemies.Count; ++i)
            {
                enemies[i].CurrentHP = enemies[i].CurrentHP - _enemyHPStep[i];
            }
        }

        private void FrameLimitReached()
        {
            _battleModel.CurrentBattleState = BattleState.Idle;
            _frameCounter = 0;
            var frontRow = _battleModel.FrontRow;

            for (var i = 0; i < frontRow.Count; ++i)
            {
                frontRow[i].CurrentHP = _charHPShouldHave[i];
                frontRow[i].ResetDamageTaken();
                frontRow[i].IsMarked = false;
            }

            var enemies = _battleModel.Enemies;
            for (var i = 0; i < enemies.Count; ++i)
            {
                enemies[i].CurrentHP = _enemyHPShouldHave[i];
                enemies[i].IsMarked = false;
            }

            var enemyMinions = _battleModel.EnemyMinions;
            foreach (var enemyMinion in enemyMinions)
            {
                enemyMinion.IsMarked = false;
            }

            var playerMinions = _battleModel.PlayerMinions;
            foreach (var playerMinion in playerMinions)
            {
                playerMinion.IsMarked = false;
            }

            var someoneAlive = false;
            var toBeDeleted = new List<ICharacter>();
            foreach (var character in frontRow)
            {
                var playerDead = character.IsDead;
                if (playerDead)
                {
                    toBeDeleted.Add(character);
                    _battleModel.PlayerDied();
                    Model.Statistics.AddToStatistic(Statistic.PartyMembersLost, 1);
                }
                someoneAlive |= !playerDead;
            }

            foreach (var character in toBeDeleted)
            {
                Model.Party.RemoveCharacter(character);
            }

            toBeDeleted.Clear();

            if (!someoneAlive)
            {
                _battleModel.CurrentBattleState = BattleState.GameOver;
                return;
            }

            var enemyAlive = false;

            foreach (var enemy in enemies)
            {
                enemy.ResetDamageTaken();
                var enemyDead = enemy.IsDead;

                if (enemyDead)
                {
                    toBeDeleted.Add(enemy);
                    _battleModel.EnemyDied();
                    Model.Statistics.AddToStatistic(Statistic.EnemiesKilled, (uint)enemies.Count);
                }

                enemyAlive |= !enemyDead;
            }

            foreach (var character in toBeDeleted)
            {
                _battleModel.RemoveEnemy(character);
            }

            toBeDeleted.Clear();
            toBeDeleted.AddRange(enemyMinions.Where(x => x.IsDead));
            toBeDeleted.AddRange(playerMinions.Where(x => x.IsDead));

            foreach (var character in toBeDeleted)
            {
                _battleModel.RemoveMinion(character);
            }

            if (enemyAlive)
            {
                return;
            }

            _battleModel.CurrentBattleState = BattleState.BattleWon;
            var statistics = Model.Statistics;
            statistics.AddToStatistic(Statistic.BattlesFought, 1);
        }
    }
}