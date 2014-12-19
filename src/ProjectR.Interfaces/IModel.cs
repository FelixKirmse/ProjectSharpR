namespace ProjectR.Interfaces
{
    public interface IModel
    {
        string PlayerName { get; set; }

        IRMap GetMap();
        ITitleModel GetTitleModel();
        IMenuModel GetMenuModel();
        IOverworldModel GetOverworldModel();
        IBattleModel GetBattleModel();
        IPreGameModel GetPreGameModel();
        IStatistics GetStatistics();
        IRaceFactory GetRaceFactory();
        ICharacterFactory GetCharacterFactory();
        ISpellFactory GetSpellFactory();
        IParty GetParty();
        IAfflictionFactory GetAfflictionFactory();
        IArcheTypeFactory GetArcheTypeFactory();
        ISkillsetFactory GetSkillsetFactory();
        ISignatureSpellFactory GetSignatureSpellFactory();
        INormalAttackFactory GetNormalAttackFactory();
        IMobPackManager GetMobPackManager();

        void CommitChanges();
        void LoadResources();
    }
}