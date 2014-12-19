namespace ProjectR.Interfaces.Model
{
    public interface IMenuModel
    {
        IMenu ActiveMenu { get; set; }

        IMenu BattleMenu { get; set; }
        IMenu SpellSelectMenu { get; set; }

        BattleMenuState BattleMenuState { get; set; }
        int SelectedSwitchIndex { get; set; }

        IMenu GetMainMenu();
        IMenu GetOptionsMenu();
        IMenu GetIngameMenu();
        IMenu GetPartyMenu();
        IMenu GetInventoryMenu();
        IMenu GetCharSwitchMenu();
        IMenu GetTargetSelectMenu();
    }
}