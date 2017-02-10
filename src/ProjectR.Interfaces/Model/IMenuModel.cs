namespace ProjectR.Interfaces.Model
{
    public interface IMenuModel
    {
        IMenu ActiveMenu { get; set; }

        IMenu BattleMenu { get; set; }
        IMenu SpellSelectMenu { get; set; }

        BattleMenuState BattleMenuState { get; set; }
        int SelectedSwitchIndex { get; set; }

        IMenu MainMenu { get; }
        IMenu OptionsMenu { get; }
        IMenu IngameMenu { get; }
        IMenu PartyMenu { get; }
        IMenu InventoryMenu { get; }
        IMenu CharSwitchMenu { get; }
        IMenu TargetSelectMenu { get; }
    }
}