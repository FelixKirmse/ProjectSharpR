using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class SpellSelect : LogicState, IMenu
    {
        private readonly IMenu _menu;
        private IBattleModel _battleModel;
        private readonly IMenuController _controller;
        private ITargetInfo _targetInfo;

        public SpellSelect()
        {
            _menu = Factories.RFactory.CreateMenu();
            _controller = new MenuController();
        }

        public override void InitializeImpl()
        {
            _battleModel = Model.BattleModel;
        }

        public override void Activate()
        {
            Initialize();
            SetCurrentState(0);
            _targetInfo = _battleModel.TargetInfo;
            ClearStates();

            var currentMP = _battleModel.CurrentAttacker.CurrentMP;

            var i = 0;
            foreach (var spellVar in _battleModel.CurrentAttacker.Spells)
            {
                ++i;
                if (i == 1 || i == 2)
                {
                    continue;
                }

                var spell = spellVar;
                var item = Factories.RFactory.CreateMenuItem(spell.Name, () =>
                {
                    _targetInfo.Spell = spell;
                    if (spell.TargetType == TargetType.Single || spell.TargetType == TargetType.Decaying)
                    {
                        Master.SetCurrentState((int) BattleMenuState.SelectTarget);
                    }
                    else
                    {
                        Master.SetCurrentState((int) BattleMenuState.Execute);
                    }
                });
                item.IsDisabled = spell.GetMPCost(_battleModel.CurrentAttacker) > currentMP + 1;
                AddState(item);
            }

            Model.MenuModel.SpellSelectMenu = this;

            for (var j = 0; j < GetStateCount(); ++j)
            {
                var item = GetMenuItem(j);
                if (item.IsDisabled)
                {
                    continue;
                }

                item.Activate();
                SetCurrentState(j);
                break;
            }
        }

        public override void Run()
        {
            _controller.ControlMenu(this, Input, () => Master.SetCurrentState((int) BattleMenuState.SelectAction));
        }

        #region IMenu Delegation

        public IState CurrentState
        {
            get { return _menu.CurrentState; } }

        public void Next()
        {
            _menu.Next();
        }

        public void Previous()
        {
            _menu.Previous();
        }

        public void AddState(IState state)
        {
            _menu.AddState(state);
        }

        public void RunCurrentState()
        {
            _menu.RunCurrentState();
        }

        public IState GetState(int index)
        {
            return _menu.GetState(index);
        }

        public void SetCurrentState(int index)
        {
            _menu.SetCurrentState(index);
        }

        public void ClearStates()
        {
            _menu.ClearStates();
        }

        public int GetStateCount()
        {
            return _menu.GetStateCount();
        }

        public bool FirstStateActive()
        {
            return _menu.FirstStateActive();
        }

        public int GetCurrentStateNumber()
        {
            return _menu.GetCurrentStateNumber();
        }

        public IMenuItem GetMenuItem(int index)
        {
            return _menu.GetMenuItem(index);
        }

        public void LeftAction()
        {
            _menu.LeftAction();
        }

        public void RightAction()
        {
            _menu.RightAction();
        }

        #endregion
    }
}