using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class BackRowSelector : LogicState
    {
        private IList<ICharacter> _backRow;
        private int _selectedIndex;
        private bool SelectedIsMarked { set { _backRow[_selectedIndex].IsMarked = value; } }

        public override void InitializeImpl()
        {
            _backRow = Model.Party.BackSeat;
        }

        public override void Activate()
        {
            Initialize();

            _selectedIndex = 0;
            if (_backRow.Count == 0)
            {
                return;
            }

            SelectedIsMarked = true;
        }

        public override void Run()
        {
            Model.CommitChanges();
            Input.Update();

            if (Input.Action(Actions.Down) || Input.Action(Actions.Up))
            {
                if (_backRow.Count == 0)
                {
                    return;
                }

                SelectedIsMarked = false;
                _selectedIndex = _selectedIndex > 3
                    ? _selectedIndex - 4
                    : _selectedIndex + 4 < _backRow.Count ? _selectedIndex + 4 : _backRow.Count - 1;
            }
            else if (Input.Action(Actions.Left))
            {
                if (_backRow.Count == 0)
                {
                    return;
                }

                SelectedIsMarked = false;
                _selectedIndex = _selectedIndex == 0 ? _backRow.Count - 1 : _selectedIndex - 1;
            }
            else if (Input.Action(Actions.Right))
            {
                if (_backRow.Count == 0)
                {
                    return;
                }

                SelectedIsMarked = false;
                _selectedIndex = _selectedIndex == _backRow.Count - 1 ? 0 : _selectedIndex + 1;
            }
            else if (Input.Action(Actions.Cancel))
            {
                if (_backRow.Count != 0)
                {
                    SelectedIsMarked = false;
                }
                _selectedIndex = 0;
                Master.Previous();
                return;
            }
            else if (Input.Action(Actions.Confirm))
            {
                if (_backRow.Count == 0)
                {
                    return;
                }

                var frontRowChar = Model.Party.FrontRow.FirstOrDefault(character => character.IsMarked);
                if (frontRowChar != null)
                {
                    frontRowChar.IsMarked = false;
                }

                SelectedIsMarked = false;
                var targetInfo = new TargetInfo
                {
                    Spell = Model.SpellFactory.GetSpell("Switch"),
                    Target = _backRow[_selectedIndex]
                };
                Model.BattleModel.TargetInfo = targetInfo;

                Model.Party.SwitchCharacters(frontRowChar, _backRow[_selectedIndex]);

                Model.BattleModel.CurrentBattleState = BattleState.Consequences;
                Model.MenuModel.BattleMenuState = BattleMenuState.SelectAction;
                Model.BattleModel.CurrentAttacker.TurnCounter = Model.BattleModel.CurrentAttacker.TimeToAction * .5d;
                Master.Previous();
                Model.Party.FrontRow[0].IsMarked = false;
                return;
            }

            if (_backRow.Count == 0)
            {
                return;
            }

            SelectedIsMarked = true;
            Model.CommitChanges();
        }
    }
}