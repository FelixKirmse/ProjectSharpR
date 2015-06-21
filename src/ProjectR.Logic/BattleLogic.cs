using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class BattleLogic : LogicState, IStateMachine
    {
        private readonly BattleWonLogic _battleWonLogic;
        private readonly GameOverLogic _gameOverLogic;
        private readonly IStateMachine _stateMachine;

        public BattleLogic()
        {
            _stateMachine = new StateMachine();
            _battleWonLogic = new BattleWonLogic();
            _gameOverLogic = new GameOverLogic();
        }

        public override void InitializeImpl()
        {
            ClearStates();
            AddState(new IdleBattleLogic());
            AddState(new BattleMenuLogic());
            AddState(new ConsequenceBattleLogic());
            AddState(_gameOverLogic);
            AddState(_battleWonLogic);
            SetCurrentState((int) BattleState.Idle);
        }

        public override void Run()
        {
            Initialize();

            SetCurrentState((int) Model.BattleModel.CurrentBattleState);
            if (CurrentState != null)
            {
                RunCurrentState();
            }

            Model.CommitChanges();

            if (_battleWonLogic.IsBattleOver)
            {
                Master.Previous();
                Model.BattleModel.ExperienceEarned = 0;
                Model.BattleModel.EndBattle();
            }

            if (_gameOverLogic.IsGameOver)
            {
                Master.Previous();
                Master.Next();
                Master.SetCurrentState(0);
                Model.BattleModel.EndBattle();
            }
        }

        #region IStateMachine Delegations

        public IState CurrentState { get { return _stateMachine.CurrentState; } }

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