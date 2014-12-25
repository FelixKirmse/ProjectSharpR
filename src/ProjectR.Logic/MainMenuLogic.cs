using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class MainMenuLogic : LogicState, IStateMachine
    {
        private readonly IStateMachine _mainMenuStateMachine;
        private readonly IMenuController _menuController;

        public MainMenuLogic()
        {
            _mainMenuStateMachine = new StateMachine();
            _menuController = new MenuController();

            AddState(Model.MenuModel.MainMenu);
            AddState(Model.MenuModel.OptionsMenu);

            var mainMenu = Model.MenuModel.MainMenu;
            mainMenu.GetMenuItem((int) MainMenuOptions.Quit).CallBack = ExitHelper.Exit;
            mainMenu.GetMenuItem((int) MainMenuOptions.Options).CallBack = Next;
            mainMenu.GetMenuItem((int) MainMenuOptions.LoadGame).IsDisabled = true;
            mainMenu.GetMenuItem((int) MainMenuOptions.NewGame).CallBack = Master.Next;
        }

        private void CancelAction()
        {
            if (FirstStateActive())
            {
                ExitHelper.Exit();
            }
            else
            {
                Previous();
            }
        }

        public override void Activate()
        {
            Model.MenuModel.MainMenu.Activate();
            SetCurrentState(0);
            Model.MenuModel.ActiveMenu = CurrentState as IMenu;
        }

        public override void Run()
        {
            var state = CurrentState;

            _menuController.ControlMenu(state as IMenu, Input, CancelAction);
            Model.CommitChanges();
        }

        #region IStateMachine Delegation
        public IState CurrentState
        {
            get { return _mainMenuStateMachine.CurrentState; } }

        public void Next()
        {
            _mainMenuStateMachine.Next();
        }

        public void Previous()
        {
            _mainMenuStateMachine.Previous();
        }

        public void AddState(IState state)
        {
            _mainMenuStateMachine.AddState(state);
        }

        public void RunCurrentState()
        {
            _mainMenuStateMachine.RunCurrentState();
        }

        public IState GetState(int index)
        {
            return _mainMenuStateMachine.GetState(index);
        }

        public void SetCurrentState(int index)
        {
            _mainMenuStateMachine.SetCurrentState(index);
        }

        public void ClearStates()
        {
            _mainMenuStateMachine.ClearStates();
        }

        public int GetStateCount()
        {
            return _mainMenuStateMachine.GetStateCount();
        }

        public bool FirstStateActive()
        {
            return _mainMenuStateMachine.FirstStateActive();
        }

        public int GetCurrentStateNumber()
        {
            return _mainMenuStateMachine.GetCurrentStateNumber();
        }
        #endregion
    }
}