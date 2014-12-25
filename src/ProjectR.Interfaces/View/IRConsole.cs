using System.Drawing;
using libtcod;

namespace ProjectR.Interfaces.View
{
    public interface IRConsole
    {
        void SetForegroundColour(TCODColor colour);

        void SetBackgroundColour(TCODColor colour);
        void SetBackgroundColour(Rectangle area, TCODColor colour);

        void SetCharacter(int x, int y, char character);
        void SetCharacter(int x, int y, int character);
        void SetCharacter(int x, int y, char character, TCODColor foreground, TCODColor background);
        void SetCharacter(int x, int y, char character, TCODColor foreground);

        void DrawHorizontalLine(int x, int y, int length);
        void DrawVerticalLine(int x, int y, int length);

        void Blit(IRConsole src, Rectangle srcRect, int dstX, int dstY, float fgAlpha = 1f, float bgAlpha = 1f);

        string GetColorControlString(TCODColor colour);

        void DrawBorder();
        void Clear();

        int Width { get; }
        int Height { get; }

        Rectangle Bounds { get; }

        void PrintString(int x, int y, string text, params object[] args);
        void PrintString(int x, int y, string text, TCODAlignment alignment, params object[] args);
        int PrintString(Rectangle rect, string text, TCODAlignment alignment, params object[] args);
        int PrintString(Rectangle rect, string text, params object[] args);
        string GetStopControl();
    }
}