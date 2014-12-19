using ProjectR.Factory;
using ProjectR.Interfaces.Model;

namespace ProjectR
{
    public class ProjectR : IProjectR
    {
        private static bool _exitGame;
        private IStateMachineSynchronizer _stateSyncer;

        public ProjectR()
        {
            _stateSyncer = RFactory.CreateStateMachineSynchronizer();
            _model = RFactory.CreateModel();
        }

        public static void Exit()
        {
            _exitGame = true;
        }

        public void SetupGameStructure()
        {
            throw new System.NotImplementedException();
        }

        public void RunGame()
        {
            throw new System.NotImplementedException();
        }
    }
}