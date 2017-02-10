using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IParty
    {
        IList<ICharacter> FrontRow { get; }
        IList<ICharacter> BackSeat { get; }
        IList<ICharacter> Reserve { get; }

        int AveragePartyLvl { get; }
        int Experience { get; }

        void Reset();
        void ResetCache();
        void AddExperience(int amount);

        void SwitchCharacters(ICharacter char1, ICharacter char2);
        void AddCharacter(ICharacter character, PartySlot slot);
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
    }
}