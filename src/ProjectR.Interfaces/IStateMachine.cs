namespace ProjectR.Interfaces
{
    public interface IStateMachine : ISynchronizeable<int>
    {
        IState CurrentState { get; }
        void Next();
        void Previous();
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