using System;

namespace ProjectR.Interfaces.Model
{
    public interface IModel
    {
        string PlayerName { get; set; }

        IRMap Map { get; }
        ITitleModel TitleModel { get; }
        IMenuModel MenuModel { get; }
        IOverworldModel OverworldModel { get; }
        IBattleModel BattleModel { get; }
        IPreGameModel PreGameModel { get; }
        IStatistics Statistics { get; }
        IRaceFactory RaceFactory { get; }
        ICharacterFactory CharacterFactory { get; }
        ISpellFactory SpellFactory { get; }
        IParty Party { get; }
        IAfflictionFactory AfflictionFactory { get; }
        IArcheTypeFactory ArcheTypeFactory { get; }
        ISkillsetFactory SkillsetFactory { get; }
        ISignatureSpellFactory SignatureSpellFactory { get; }
        INormalAttackFactory NormalAttackFactory { get; }
        IMobPackManager MobPackManager { get; }
        ILoadResourcesModel LoadResourcesModel { get; }

        void CommitChanges();
        void LoadResources();
    }
}