namespace ProjectR.Interfaces
{
    public interface IStateMachine
    {
        void Next();
        void Previous();
        IState CurrentState { get; }
        void AddState(IState state);
        void RunCurrentState();
        IState GetState(int index);
        void SetCurrentState(int index);
        void ClearStates();
        int GetStateCount();
        bool FirstStateActive();
        int GetCurrentStateNumber();
    }
}