using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class ActionSelectView : InitializeableModelState
    {
        private IMenuModel _menuModel;
        private readonly IMenuDrawer _drawer;
        private readonly IStatScreenDrawer _statDrawer;
        private IRConsole _root;

        public ActionSelectView()
        {
            _drawer = new MenuDrawer();
            _statDrawer = new StatScreenDrawer();
        }

        public override void InitializeImpl()
        {
            _menuModel = Model.MenuModel;
            _root = RConsole.RootConsole;
            _statDrawer.SetPosition(80, 3);
        }

        public override void Run()
        {
            var battleMenu = _menuModel.BattleMenu;
            if (battleMenu != null)
            {
                _drawer.DrawMenu(battleMenu, 4, 54, 1);
            }

            _root.SetForegroundColour(TCODColor.white);
            _root.PrintString(3, 52, "Action Select:");
            _root.DrawVerticalLine(19, 52, 12);
            _statDrawer.DrawStats(Model.BattleModel.CurrentAttacker);
        }
    }
}