using System.Collections.Generic;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class FrontRowSelector : LogicState
    {
        private const int FrontRowSize = 4;
        private IList<ICharacter> _frontRow;
        private int _selectedIndex;

        public override void InitializeImpl()
        {
            _frontRow = Model.BattleModel.FrontRow;
        }

        public override void Activate()
        {
            Initialize();
            if (_selectedIndex < _frontRow.Count)
            {
                _frontRow[_selectedIndex].IsMarked = false;
            }
            _selectedIndex = 0;
            _frontRow[_selectedIndex].IsMarked = true;
        }

        public override void Run()
        {
            var actualSize = _frontRow.Count;
            if (_selectedIndex < actualSize)
            {
                _frontRow[_selectedIndex].IsMarked = true;
            }

            Model.CommitChanges();

            Input.Update();
            if (Input.Action(Actions.Left))
            {
                if (_selectedIndex < actualSize)
                {
                    _frontRow[_selectedIndex].IsMarked = false;
                }

                _selectedIndex = _selectedIndex == 0 ? FrontRowSize - 1 : _selectedIndex - 1;
            }
            else if (Input.Action(Actions.Right))
            {
                if (_selectedIndex < actualSize)
                {
                    _frontRow[_selectedIndex].IsMarked = false;
                }

                _selectedIndex = _selectedIndex == FrontRowSize - 1 ? 0 : _selectedIndex + 1;
            }
            else if (Input.Action(Actions.Cancel))
            {
                if (_selectedIndex < actualSize)
                {
                    _frontRow[_selectedIndex].IsMarked = false;
                }

                _selectedIndex = 0;
                Master.Previous();
                return;
            }
            else if (Input.Action(Actions.Confirm))
            {
                Master.Next();
                return;
            }

            if (_selectedIndex < actualSize)
            {
                _frontRow[_selectedIndex].IsMarked = false;
            }
            Model.MenuModel.SelectedSwitchIndex = _selectedIndex;
            Model.CommitChanges();
        }
    }
}