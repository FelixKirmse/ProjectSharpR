using ProjectR.Factory;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Model;

namespace ProjectR
{
    public class ProjectR : IProjectR
    {
        private static bool _exitGame;
        private IStateMachineSynchronizer _stateSyncer;
        private IRModel _model;

        public ProjectR()
        {
            _stateSyncer = Factories.RFactory.CreateStateMachineSynchronizer();
            _model = Factories.RFactory.CreateModel();
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