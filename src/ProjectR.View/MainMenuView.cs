using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class MainMenuView : ModelState
    {
        private readonly IRConsole _menuConsole;
        private readonly IMenuDrawer _menuDrawer;
        private readonly IRConsole _rootConsole;
        private readonly int _rootHeight;
        private readonly int _rootWidth;

        public MainMenuView()
        {
            _rootConsole = RConsole.RootConsole;
            _rootWidth = _rootConsole.Width;
            _rootHeight = _rootConsole.Height;
            _menuConsole = new RConsole(9, 4);
            _menuDrawer = new MenuDrawer();
        }

        public override void Run()
        {
            _menuDrawer.DrawMenu(Model.MenuModel.ActiveMenu, 0, 0, 0, _menuConsole, 0,
                Model.MenuModel.ActiveMenu.GetStateCount() - 1);
            _rootConsole.Blit(_menuConsole, _menuConsole.Bounds, 5, _rootHeight - 9);
        }
    }
}