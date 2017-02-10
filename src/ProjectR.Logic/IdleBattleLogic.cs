using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Logic
{
    public class IdleBattleLogic : LogicState
    {
        private readonly ICharacterSpellSelect _spellSelect;
        private int _enemyLeftOff;
        private int _enemyMinionLeftOff;
        private ICharacter _lastAttacker;

        private int _playerLeftOff;
        private int _playerMinionLeftOff;

        public IdleBattleLogic()
        {
            _spellSelect = new CharacterSpellSelect();
            _playerLeftOff = 0;
            _enemyLeftOff = 0;
            _enemyMinionLeftOff = 0;
            _playerMinionLeftOff = 0;
            _lastAttacker = null;
        }

        public override void Run()
        {
            var battleModel = Model.BattleModel;
            var frontRow = battleModel.FrontRow;

            if (_lastAttacker != null)
            {
                _lastAttacker.TurnEnded();
            }

            for (var i = _playerLeftOff; i < frontRow.Count; ++i)
            {
                if (!frontRow[i].UpdateTurnCounter())
                {
                    continue;
                }

                battleModel.CurrentBattleState = BattleState.BattleMenu;
                _playerLeftOff = i + 1;
                battleModel.CurrentAttacker = frontRow[i];
                battleModel.IsEnemyTurn = false;
                _lastAttacker = frontRow[i];
                return;
            }

            _playerLeftOff = 0;

            var cont = UpdateAI(battleModel.PlayerMinions, ref _playerMinionLeftOff, false, battleModel);
            if (cont)
            {
                cont = UpdateAI(battleModel.Enemies, ref _enemyLeftOff, true, battleModel);
            }

            if (cont)
            {
                UpdateAI(battleModel.EnemyMinions, ref _enemyMinionLeftOff, true, battleModel);
            }

            foreach (var character in Model.Party.BackSeat.Where(character => character.UpdateTurnCounter(false)))
            {
                character.Heal(character.Stats.GetTotalStat(BaseStat.HP) * .2d);
                character.ResetDamageTaken();
            }
        }

        private bool UpdateAI(IList<ICharacter> list, ref int counter, bool enemyTurn, IBattleModel battleModel)
        {
            for (var i = counter; i < list.Count; ++i)
            {
                if (!list[i].UpdateTurnCounter())
                {
                    continue;
                }

                battleModel.TargetInfo = _spellSelect.SelectSpell(list[i], battleModel, enemyTurn);
                counter = i + 1;
                battleModel.CurrentBattleState = BattleState.Consequences;
                battleModel.CurrentAttacker = list[i];
                battleModel.IsEnemyTurn = enemyTurn;
                _lastAttacker = list[i];
                return false;
            }

            counter = 0;
            return true;
        }
    }
}