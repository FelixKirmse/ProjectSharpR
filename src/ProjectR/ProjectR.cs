using ProjectR.Factory;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR
{
    public class ProjectR : IProjectR
    {
        private static bool _exitGame;
        private IStateMachineSynchronizer _stateSyncer;
        private IRModel _model;
        private IConsoleView _view;

        public ProjectR()
        {
            _stateSyncer = Factories.RFactory.CreateStateMachineSynchronizer();
            _model = Factories.RFactory.CreateModel();
            _view = Factories.RFactory.CreateConsoleView();
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