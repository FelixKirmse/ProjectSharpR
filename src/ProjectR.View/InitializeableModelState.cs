namespace ProjectR.View
{
    public abstract class InitializeableModelState : ModelState
    {
        private bool _initialized;

        public virtual void InitializeImpl()
        {
        }

        public void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            InitializeImpl();
            _initialized = true;
        }
    }
}