namespace ProjectR.Interfaces.Model
{
    public abstract class ModelState : IState
    {
        public static IModel Model { get; set; }
        protected IStateMachine Master { get; private set; }

        public virtual void Activate()
        {
        }

        public virtual void Deactivate()
        {
        }

        public abstract void Run();

        public void SetStateMachine(IStateMachine machine)
        {
            Master = machine;
        }
    }
}