using libtcod;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class ConsoleView : StateMachine, IConsoleView
    {
        public ConsoleView()
        {
            RConsole.InitializeRootConsole((int) (1920d / 8 / 2), (int) (1080d / 8 / 2));
            TCODSystem.setFps(30);
            RConsole.RootConsole.SetBackgroundColour(TCODColor.black);
            RConsole.RootConsole.SetForegroundColour(TCODColor.white);
        }

        public void Show()
        {
            RConsole.RootConsole.Clear();
            RunCurrentState();
            RConsole.Draw();
        }

        public void InitializeStates()
        {
            AddState(new LoadResourcesView());
            AddState(new TitleScreenView());
            AddState(new MainMenuView());
            AddState(new PreGameView());
            AddState(new OverworldView());
            AddState(new BattleView());
        }

        public void Notify()
        {
            if (RConsole.ConsoleWindowClosed)
            {
                ExitHelper.Exit(0, "Window was closed");
            }

            Show();
        }
    }
}