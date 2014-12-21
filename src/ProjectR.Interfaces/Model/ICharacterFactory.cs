using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ICharacterFactory
    {
        IList<string> BossList { get; } 
        
        void LoadCharacters();
        ICharacter CreateRandomCharacter(int level = 1, IRaceTemplate race = null);
        ICharacter CreateRandomEnemy(int level = 1);
        ICharacter GetSpecialCharacter(string name);
        IList<IAffliction> GetPassives(ICharacter character);
    }
}