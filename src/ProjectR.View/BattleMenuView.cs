using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.View
{
    public class BattleMenuView : InitializeableModelState, IStateMachine
    {
        private readonly IStateMachine _stateMachine;

        public BattleMenuView()
        {
            _stateMachine = new StateMachine();
        }

        public override void InitializeImpl()
        {
            AddState(new ActionSelectView());
            AddState(new TargetSelectView());
            AddState(new SpellSelectView());
            AddState(new SwitchView());
            AddState(new ConvinceDrawer());
            AddState( /*Execute*/null);
            AddState(new SetFormationView());
        }

        public override void Run()
        {
            Initialize();

            var state = Model.MenuModel.BattleMenuState;
            switch (state)
            {
                case BattleMenuState.SetFormation:
                case BattleMenuState.SelectAction:
                case BattleMenuState.SelectTarget:
                case BattleMenuState.SelectSpell:
                case BattleMenuState.Switch:
                    GetState((int) BattleMenuState.SelectAction).Run();
                    break;
            }

            var stateObj = GetState((int) state);
            if (stateObj != null)
            {
                stateObj.Run();
            }
        }

        #region IStateMachine Delegation

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