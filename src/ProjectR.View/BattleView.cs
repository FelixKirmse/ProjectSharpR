using ProjectR.Interfaces;

namespace ProjectR.View
{
    public class BattleView : InitializeableModelState, IStateMachine
    {
        private readonly CommonBattleView _common;
        private readonly IStateMachine _stateMachine;

        public BattleView()
        {
            _stateMachine = new StateMachine();
            _common = new CommonBattleView();
        }

        public override void Run()
        {
            Initialize();

            _common.Run();

            IState currentState = GetState((int) Model.BattleModel.CurrentBattleState);
            if (currentState != null)
            {
                currentState.Run();
            }
        }

        public override void InitializeImpl()
        {
            AddState(null);
            AddState(new BattleMenuView());
            AddState( /*Consequences*/ null);
            AddState( /*GameOver*/ null);
            AddState(new BattleWonView());
            SetCurrentState(0);
            _common.Activate();
        }

        #region IStateMachine Delegation

        public void Next()
        {
            _stateMachine.Next();
        }

        public void Previous()
        {
            _stateMachine.Previous();
        }

        public IState CurrentState { get { return _stateMachine.CurrentState; } }

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

        #endregion
    }
}