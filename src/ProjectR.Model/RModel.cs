using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class RModel : IRModel
    {
        public string PlayerName { get; set; }
        public IRMap Map { get; private set; }
        public ITitleModel TitleModel { get; private set; }
        public IMenuModel MenuModel { get; private set; }
        public IOverworldModel OverworldModel { get; private set; }
        public IBattleModel BattleModel { get; private set; }
        public IPreGameModel PreGameModel { get; private set; }
        public IStatistics Statistics { get; private set; }
        public IRaceFactory RaceFactory { get; private set; }
        public ICharacterFactory CharacterFactory { get; private set; }
        public ISpellFactory SpellFactory { get; private set; }
        public IParty Party { get; private set; }
        public IAfflictionFactory AfflictionFactory { get; private set; }
        public IArcheTypeFactory ArcheTypeFactory { get; private set; }
        public ISkillsetFactory SkillsetFactory { get; private set; }
        public ISignatureSpellFactory SignatureSpellFactory { get; private set; }
        public INormalAttackFactory NormalAttackFactory { get; private set; }
        public IMobPackManager MobPackManager { get; private set; }

        public RModel()
        {
            Map = new RMap();
            Statistics = new Statistics();
            MobPackManager = new MobPackManager(this);
            TitleModel = new TitleModel();
            MenuModel = new MenuModel();
            PreGameModel = new PreGameModel(this);
            OverworldModel = new OverworldModel(this);
            BattleModel = new BattleModel(this);
            RaceFactory = new RaceFactory(this);
            CharacterFactory = new CharacterFactory(this);
            SpellFactory = new Spellfactory(this);
            Party = new Party(this);
            AfflictionFactory = new AfflictionFactory(this);
            ArcheTypeFactory = new ArcheTypeFactory(this);
            SkillsetFactory = new SkillsetFactory(this);
        }

        public void CommitChanges()
        {
            throw new System.NotImplementedException();
        }

        public void LoadResources()
        {
            throw new System.NotImplementedException();
        }

        public void AddObserver(IObserver observer)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyObservers()
        {
            throw new System.NotImplementedException();
        }
    }
}