using System.Collections.Generic;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class SetFormationLogic : LogicState
    {
        private const int FrontRowSize = 4;
        private IList<ICharacter> _frontRow;
        private bool _selectedFirst;
        private int _selectedIndex1;
        private int _selectedIndex2;

        private bool SelectedMarked1 { set { _frontRow[_selectedIndex1].IsMarked = value; } }
        private bool SelectedMarked2 { set { _frontRow[_selectedIndex2].IsMarked = value; } }

        public override void InitializeImpl()
        {
            _frontRow = Model.BattleModel.FrontRow;
        }

        public override void Activate()
        {
            Initialize();

            if (_selectedIndex1 < _frontRow.Count)
            {
                SelectedMarked1 = false;
            }

            if (_selectedIndex2 < _frontRow.Count)
            {
                SelectedMarked2 = false;
            }

            _selectedIndex1 = 0;
            _selectedIndex2 = 0;
            _selectedFirst = false;
            SelectedMarked1 = true;
        }

        public override void Run()
        {
            if (_selectedFirst)
            {
                Run(ref _selectedIndex2);
            }
            else
            {
                Run(ref _selectedIndex1);
            }
        }

        public void Run(ref int selectedIndex)
        {
            var actualSize = _frontRow.Count;
            if (selectedIndex < actualSize)
            {
                _frontRow[selectedIndex].IsMarked = true;
            }

            Model.CommitChanges();
            Input.Update();

            if (Input.Action(Actions.Left))
            {
                if (selectedIndex < actualSize)
                {
                    _frontRow[selectedIndex].IsMarked = false;
                }

                do
                {
                    selectedIndex = selectedIndex == 0 ? FrontRowSize - 1 : _selectedIndex1 - 1;
                } while (_selectedFirst && selectedIndex == _selectedIndex1);
            }
            else if (Input.Action(Actions.Right))
            {
                if (selectedIndex < actualSize)
                {
                    _frontRow[selectedIndex].IsMarked = false;
                }

                do
                {
                    selectedIndex = selectedIndex == FrontRowSize - 1 ? 0 : selectedIndex + 1;
                } while (_selectedFirst && selectedIndex == _selectedIndex1);
            }
            else if (Input.Action(Actions.Cancel))
            {
                if (selectedIndex < actualSize)
                {
                    _frontRow[selectedIndex].IsMarked = false;
                }

                selectedIndex = 0;

                if (_selectedFirst)
                {
                    _selectedFirst = false;
                }
                else
                {
                    Master.SetCurrentState((int) BattleMenuState.SelectAction);
                }

                return;
            }
            else if (Input.Action(Actions.Confirm))
            {
                if (!_selectedFirst)
                {
                    _selectedFirst = true;
                }
                else
                {
                    SelectedMarked1 = false;
                    SelectedMarked2 = false;
                    _frontRow[_selectedIndex1].TurnCounter = _frontRow[_selectedIndex1].TimeToAction * .5d;
                    Model.Party.SwitchCharacters(_frontRow[_selectedIndex1], _frontRow[_selectedIndex2]);
                    Model.BattleModel.CurrentBattleState = BattleState.Consequences;
                    Model.MenuModel.BattleMenuState = BattleMenuState.SelectAction;
                    Model.BattleModel.TargetInfo.Spell = Model.SpellFactory.GetSpell("Switch");
                    return;
                }
            }

            if (selectedIndex < actualSize)
            {
                _frontRow[selectedIndex].IsMarked = true;
            }

            Model.MenuModel.SelectedSwitchIndex = selectedIndex;
            Model.CommitChanges();
        }
    }
}