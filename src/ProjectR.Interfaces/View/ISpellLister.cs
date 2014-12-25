using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface ISpellLister
    {
        void SetPosition(int x, int y);
        void Draw(ICharacter character, IRConsole target = null);
    }
}