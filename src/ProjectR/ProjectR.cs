using System;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR
{
    public class ProjectR : IProjectR
    {
        private static bool _exitGame;
        private IRModel _model;
        private IStateMachineSynchronizer _stateSyncer;
        private IConsoleView _view;

        public ProjectR()
        {
            _stateSyncer = Factories.RFactory.CreateStateMachineSynchronizer();
            _model = Factories.RFactory.CreateModel();
            _view = Factories.RFactory.CreateConsoleView();
            _logic = Factories.RFactory.CreateLogic();
        }

        public void SetupGameStructure()
        {
            throw new NotImplementedException();
        }

        public void RunGame()
        {
            throw new NotImplementedException();
        }

        public static void Exit()
        {
            _exitGame = true;
        }
    }
}