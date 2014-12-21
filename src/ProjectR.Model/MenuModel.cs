using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class MenuModel : IMenuModel
    {
        public IMenu ActiveMenu { get; set; }
        public IMenu BattleMenu { get; set; }
        public IMenu SpellSelectMenu { get; set; }
        public BattleMenuState BattleMenuState { get; set; }
        public int SelectedSwitchIndex { get; set; }
        public IMenu MainMenu { get; private set; }
        public IMenu OptionsMenu { get; private set; }
        public IMenu IngameMenu { get; private set; }
        public IMenu PartyMenu { get; private set; }
        public IMenu InventoryMenu { get; private set; }
        public IMenu CharSwitchMenu { get; private set; }
        public IMenu TargetSelectMenu { get; private set; }

        public MenuModel()
        {
            MainMenu = new Menu();
            OptionsMenu = new Menu();
            ActiveMenu = MainMenu;
            SelectedSwitchIndex = 0;

            SetupMainMenu(MainMenu);
            SetupMainMenu(OptionsMenu);
            OptionsMenu.GetState(2).Activate();
        }

        private void SetupMainMenu(IStateMachine menu)
        {
            menu.AddState(new MenuItem("New Game"));
            menu.AddState(new MenuItem("Load Game"));
            menu.AddState(new MenuItem("Options"));
            menu.AddState(new MenuItem("Quit"));
            menu.GetState((int) MainMenuOptions.NewGame).Activate();
        }
    }
}