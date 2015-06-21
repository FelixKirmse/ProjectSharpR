using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class SwitchLogic : LogicState, IStateMachine
    {
        private readonly IStateMachine _stateMachine;

        public SwitchLogic()
        {
            _stateMachine = new StateMachine();
        }

        public override void InitializeImpl()
        {
            AddState(new FrontRowSelector());
            AddState(new BackRowSelector());
            SetCurrentState(0);
        }

        public override void Activate()
        {
            Initialize();
        }

        public override void Run()
        {
            RunCurrentState();
        }

        #region IStateMachine Delegation

        public IState CurrentState { get { return _stateMachine.CurrentState; } }

        public void Next()
        {
            _stateMachine.Next();
        }

        public void Previous()
        {
            if (FirstStateActive())
            {
                Master.SetCurrentState((int) BattleMenuState.SelectAction);
            }
            else
            {
                _stateMachine.Previous();
            }
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
            _stateMachine.SetCurrentState(index);
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