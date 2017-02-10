using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface IPreGameModel
    {
        int AvailableMasteryPoints { get; set; }
        string PlayerName { get; set; }
        bool ShowStats { get; set; }

        IRaceTemplate RaceTemplate { set; }
        IArcheType ArcheType { set; }
        ISkillset Skillset { set; }
        ISpell SignatureSpell { set; }
        ISpell NormalAttack { set; }

        ICharacter Character { get; }

        void SetMastery(EleMastery mastery, int value);
    }
}