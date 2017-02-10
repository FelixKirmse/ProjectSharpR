using libtcod;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR
{
    public class ProjectR : IProjectR
    {
        private static bool _exitGame;
        private readonly IRLogic _logic;
        private readonly IRModel _model;
        private readonly IStateMachineSynchronizer _stateSyncer;
        private readonly IConsoleView _view;

        public ProjectR()
        {
            _stateSyncer = Factories.RFactory.CreateStateMachineSynchronizer();
            _model = Factories.RFactory.CreateModel();
            _view = Factories.RFactory.CreateConsoleView();
            _logic = Factories.RFactory.CreateLogic();

            ExitHelper.ExitAction = Exit;
        }

        public void SetupGameStructure()
        {
            _stateSyncer.AddSynchronizeable(_view);
            _stateSyncer.AddSynchronizeable(_logic);
            _view.InitializeStates();
            _logic.InitializeStates();
            _model.AddObserver(_view);
            _stateSyncer.Sync(0);
        }

        public void RunGame()
        {
            _model.CommitChanges();
            do
            {
                TCODConsole.checkForKeypress((int) TCODKeyStatus.KeyPressed);
                _logic.RunCurrentState();
            } while (!_exitGame && !TCODConsole.isWindowClosed());
        }

        public static void Exit()
        {
            _exitGame = true;
        }
    }
}