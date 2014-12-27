using System.Threading.Tasks;

namespace ProjectR.Logic
{
    public class LoadResourcesLogic : LogicState
    {
        private bool _finished;
        private bool _started;

        public override void Run()
        {
            if (!_started)
            {
                Task.Factory.StartNew(_LoadResources);
                _started = true;
            }

            if (_finished)
            {
                Master.Next();
            }

            Model.CommitChanges();
        }

        private void _LoadResources()
        {
            Model.LoadResources();
            _finished = true;
        }
    }
}