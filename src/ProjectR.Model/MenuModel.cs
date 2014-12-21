using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class MenuModel : IMenuModel
    {
        public IMenu ActiveMenu { get; set; }
        public IMenu BattleMenu { get; set; }
        public IMenu SpellSelectMenu { get; set; }
        public BattleMenuState BattleMenuState { get; set; }
        public int SelectedSwitchIndex { get; set; }
        public IMenu MainMenu { get; private set; }
        public IMenu OptionsMenu { get; private set; }
        public IMenu IngameMenu { get; private set; }
        public IMenu PartyMenu { get; private set; }
        public IMenu InventoryMenu { get; private set; }
        public IMenu CharSwitchMenu { get; private set; }
        public IMenu TargetSelectMenu { get; private set; }

        public MenuModel()
        {
            MainMenu = new Menu();
            OptionsMenu = new Menu();
            ActiveMenu = MainMenu;
            SelectedSwitchIndex = 0;

            SetupMainMenu(MainMenu);
            SetupMainMenu(OptionsMenu);
            OptionsMenu.GetState(2).Activate();
        }

        private void SetupMainMenu(IStateMachine menu)
        {
            menu.AddState(new MenuItem("New Game"));
            menu.AddState(new MenuItem("Load Game"));
            menu.AddState(new MenuItem("Options"));
            menu.AddState(new MenuItem("Quit"));
            menu.GetState((int) MainMenuOptions.NewGame).Activate();
        }
    }


    public class MenuItem : IMenuItem
    {
        public bool IsDisabled { get; set; }
        public bool IsSelected { get; private set; }
        public string Label { get; set; }
        public Action CallBack { set; private get; }

        private Action _leftAction;
        private Action _rightAction;

        public MenuItem(string label)
        {
            Label = label;
            IsSelected = false;
            IsDisabled = false;
            CallBack = delegate { };
            _leftAction = delegate { };
            _rightAction = delegate { };
        }

        public MenuItem(string label, Action callBack)
            : this(label)
        {
            CallBack = callBack;
        }

        public void Activate()
        {
            IsSelected = true;
        }

        public void Deactivate()
        {
            IsSelected = false;
        }

        public void Run()
        {
            CallBack();
        }

        public void SetStateMachine(IStateMachine machine)
        {
        }
        
        public void SetLeftAction(Action leftAction)
        {
            _leftAction = leftAction;
        }

        public void SetRightAction(Action rightAction)
        {
            _rightAction = rightAction;
        }

        public void LeftAction()
        {
            _leftAction();
        }

        public void RightAction()
        {
            _rightAction();
        }
    }

    public class Menu : StateMachine, IMenu
    {
        private IMenuItem CurrentMenuItem { get { return CurrentState as IMenuItem; } }

        public void Activate()
        {
            SetCurrentState(0);
        }

        public void Deactivate()
        {
        }

        public void Run()
        {
            if (!CurrentMenuItem.IsDisabled)
            {
                RunCurrentState();
            }
        }

        public void SetStateMachine(IStateMachine machine)
        {
        }

        public void LeftAction()
        {
            CurrentMenuItem.LeftAction();
        }

        public void RightAction()
        {
            CurrentMenuItem.RightAction();
        }

        public override void Next()
        {
            var stateCount = GetStateCount();
            for (var i = 0; i < stateCount; ++i)
            {
                var menuItem = GetState(i) as IMenuItem;
                Debug.Assert(menuItem != null, "menuItem != null");
                if (!menuItem.IsSelected)
                {
                    continue;
                }

                menuItem.Deactivate();
                SetCurrentState(i == stateCount - 1 ? 0 : i + 1);
                var nextMenuItem = CurrentMenuItem;
                nextMenuItem.Activate();
                if (nextMenuItem.IsDisabled)
                {
                    Next();
                }
                break;
            }
        }

        public override void Previous()
        {
            var stateCount = GetStateCount();
            for (var i = 0; i < stateCount; ++i)
            {
                var menuItem = GetState(i) as IMenuItem;
                Debug.Assert(menuItem != null, "menuItem != null");
                if (!menuItem.IsSelected)
                {
                    continue;
                }

                menuItem.Deactivate();
                SetCurrentState(i == 0 ? stateCount - 1 : i - 1);
                var lastMenuItem = CurrentMenuItem;
                lastMenuItem.Activate();
                if (lastMenuItem.IsDisabled)
                {
                    Previous();
                }
                break;
            }
        }
    }

    public class StateMachine : IStateMachine, ISynchronizeable<int>
    {
        private readonly List<IState> _states;
        private int _currentState;
        private ISynchronizer<int> _synchronizer;

        public StateMachine()
        {
            _states = new List<IState>();
            _currentState = -1;
            _synchronizer = null;
        }

        public virtual void Next()
        {
            Sync(_currentState + 1);
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public virtual void Previous()
        {
            Sync(_currentState - 1);
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public IState CurrentState
        {
            get { return _states[_currentState]; }
        }


        public void AddState(IState state)
        {
            if (state != null)
            {
                state.SetStateMachine(this);
            }

            _states.Add(state);
        }

        public void RunCurrentState()
        {
            var state = CurrentState;

            if (state != null)
            {
                state.Run();
            }

            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public IState GetState(int index)
        {
            return _states[index];
        }

        public virtual void SetCurrentState(int index)
        {
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
            else
            {
                Sync(index);
            }
        }

        public void ClearStates()
        {
            _states.Clear();
        }

        public int GetStateCount()
        {
            return _states.Count;
        }

        public bool FirstStateActive()
        {
            return _currentState == 0;
        }

        public int GetCurrentStateNumber()
        {
            return _currentState;
        }

        public void Sync(int value)
        {
            if (_currentState == value || _states.Count == 0)
            {
                return;
            }

            if (_currentState != -1 && CurrentState != null)
            {
                CurrentState.Deactivate();
            }

            _currentState = value;

            if (CurrentState != null)
            {
                CurrentState.Activate();
            }
        }

        public void SetSynchronizer(ISynchronizer<int> syncer)
        {
            _synchronizer = syncer;
        }
    }
}