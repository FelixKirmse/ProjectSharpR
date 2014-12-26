using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class BattleMenuLogic : LogicState, IStateMachine
    {
        private readonly IStateMachine _stateMachine;
        private IState _lastState;

        public BattleMenuLogic()
        {
            _stateMachine = new StateMachine();
        }

        public override void InitializeImpl()
        {
            AddState(new ActionSelect());
            AddState(new TargetSelect());
            AddState(new SpellSelect());
            AddState(new SwitchLogic());
            AddState(new ConvinceLogic());
            AddState(/*Execute*/null);
            AddState(new SetFormationLogic());
            SetCurrentState((int) BattleMenuState.SelectAction);
        }

        public override void Run()
        {
            Initialize();

            var currentState = GetState((int) Model.MenuModel.BattleMenuState);
            if (currentState != _lastState)
            {
                _lastState.Deactivate();
                currentState.Activate();
            }

            currentState.Run();

            if (Model.MenuModel.BattleMenuState == BattleMenuState.Execute)
            {
                Model.BattleModel.CurrentBattleState = BattleState.Consequences;
                SetCurrentState((int) BattleMenuState.SelectAction);
            }

            _lastState = currentState;
        }

        #region IStateMachine Delegation
        public IState CurrentState
        {
            get { return _stateMachine.CurrentState; } }

        public void Next()
        {
            _stateMachine.Next();
        }

        public void Previous()
        {
            _stateMachine.Previous();
        }

        public void AddState(IState state)
        {
            _stateMachine.AddState(state);
        }

        public void RunCurrentState()
        {
            _stateMachine.RunCurrentState();
        }

        public IState GetState(int index)
        {
            return _stateMachine.GetState(index);
        }

        public void SetCurrentState(int index)
        {
            Model.MenuModel.BattleMenuState = (BattleMenuState) index;
            _stateMachine.SetCurrentState(index);
            _lastState = CurrentState;
        }

        public void ClearStates()
        {
            _stateMachine.ClearStates();
        }

        public int GetStateCount()
        {
            return _stateMachine.GetStateCount();
        }

        public bool FirstStateActive()
        {
            return _stateMachine.FirstStateActive();
        }

        public int GetCurrentStateNumber()
        {
            return _stateMachine.GetCurrentStateNumber();
        }

        public void Sync(int value)
        {
            _stateMachine.Sync(value);
        }

        public void SetSynchronizer(ISynchronizer<int> syncer)
        {
            _stateMachine.SetSynchronizer(syncer);
        }
        #endregion
    }
}