namespace ProjectR.Interfaces.Model
{
    public interface IMenu : IStateMachine, IState
    {
        void LeftAction();
        void RightAction();
    }
}