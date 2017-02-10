using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface IStatScreenDrawer : IRConsole
    {
        void DrawStats(ICharacter character, IRConsole targetConsole = null);
        void SetPosition(int x, int y);
    }
}