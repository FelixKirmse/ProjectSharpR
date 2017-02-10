using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Logic
{
    public interface ICharacterSpellSelect
    {
        ITargetInfo SelectSpell(ICharacter character, IBattleModel battleModel, bool isEnemy);
    }
}