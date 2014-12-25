using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class SetFormationView : ModelState
    {
        private readonly IStatScreenDrawer _drawer;
        private readonly ISpellLister _lister;

        public SetFormationView()
        {
            _drawer = new StatScreenDrawer();
            _lister = new SpellLister();

            _drawer.SetPosition(80, 3);
            _lister.SetPosition(80, 35);
        }

        public override void Run()
        {
            RConsole.RootConsole.SetForegroundColour(TCODColor.white);
            RConsole.RootConsole.PrintString(22, 52, "Select 2 Characters to switch.");

            var character = Model.BattleModel.FrontRow[Model.MenuModel.SelectedSwitchIndex];

            _drawer.DrawStats(character);
            _lister.Draw(character);
        }
    }
}