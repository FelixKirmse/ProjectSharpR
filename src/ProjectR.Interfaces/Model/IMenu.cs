namespace ProjectR.Interfaces.Model
{
    public interface IMenu : IStateMachine, IState
    {
        IMenuItem GetMenuItem(int index);
        void LeftAction();
        void RightAction();
    }
}