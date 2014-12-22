using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface ICharDescriptionDrawer : IRConsole
    {
        void SetPosition(int x, int y);
        void DrawSummary(ICharacter character, IRConsole target = null);
    }
}