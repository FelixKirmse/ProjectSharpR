using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface IMenuDrawer
    {
        void DrawMenu(IMenu menu, int row, int col, int offset = 0);
        void DrawMenu(IMenu menu, IRConsole target, int row = 0, int col = 0, int offset = 0);
        void DrawMenuPart(IMenu menu, int startItem, int endItem, int row = 0, int col = 0, int offset = 0);
        void DrawMenu(IMenu menu, int row, int col, int offset, IRConsole target, int startItem, int endItem);
    }
}