namespace ProjectR.Interfaces
{
    public interface IState
    {
        void Activate();
        void Deactivate();
        void Run();
        void SetStateMachine(IStateMachine machine);
    }
}