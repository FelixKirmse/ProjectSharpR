using System.Collections.Generic;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class TargetSelect : LogicState
    {
        private int _activeIndex;
        private IList<ICharacter> _activeRow;
        private IBattleModel _battleModel;
        private bool _enemyRowSelected;
        private ITargetInfo _targetInfo;

        public TargetSelect()
        {
            _activeIndex = 0;
            _enemyRowSelected = true;
        }

        public override void InitializeImpl()
        {
            _battleModel = Model.BattleModel;
        }

        public override void Activate()
        {
            Initialize();

            _enemyRowSelected = !_battleModel.TargetInfo.Spell.IsSupportSpell;
            _activeRow = _enemyRowSelected ? _battleModel.Enemies : _battleModel.FrontRow;
            _activeIndex = 0;
            _activeRow[_activeIndex].IsMarked = true;
            _targetInfo = _battleModel.TargetInfo;
            _targetInfo.Target = _activeRow[_activeIndex];
        }

        public override void Run()
        {
            Model.CommitChanges();
            _activeRow = (_enemyRowSelected ? _battleModel.Enemies : _battleModel.FrontRow);

            Input.Update();
            if (Input.Action(Actions.Up) || Input.Action(Actions.Down))
            {
                _activeRow[_activeIndex].IsMarked = false;
                _enemyRowSelected = !_enemyRowSelected;
                _activeRow = _enemyRowSelected ? _battleModel.Enemies : _battleModel.FrontRow;
            }
            else if (Input.Action(Actions.Left))
            {
                _activeRow[_activeIndex].IsMarked = false;
                _activeIndex = _activeIndex == 0 ? _activeRow.Count - 1 : _activeIndex - 1;
            }
            else if (Input.Action(Actions.Right))
            {
                _activeRow[_activeIndex].IsMarked = false;
                _activeIndex = _activeIndex == _activeRow.Count - 1 ? 0 : _activeIndex + 1;
            }
            else if (Input.Action(Actions.Confirm))
            {
                _activeRow[_activeIndex].IsMarked = false;
                Master.SetCurrentState((int) BattleMenuState.Execute);
                _targetInfo.Target = _activeRow[_activeIndex];
                return;
            }
            else if (Input.Action(Actions.Cancel))
            {
                Master.SetCurrentState((int) BattleMenuState.SelectAction);
                _activeRow[_activeIndex].IsMarked = false;
                Model.CommitChanges();
                return;
            }

            _activeRow[_activeIndex].IsMarked = true;
            _targetInfo.Target = _activeRow[_activeIndex];
            Model.CommitChanges();
        }
    }
}