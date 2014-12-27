using System.Diagnostics;
using System.Drawing;
using System.Text;
using libtcod;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class RConsole : IRConsole
    {
        private readonly TCODConsole _console;

        public static IRConsole RootConsole { get; private set; }
        public static bool ConsoleWindowClosed { get { return TCODConsole.isWindowClosed(); } }

        public RConsole(int width, int height)
        {
            _console = new TCODConsole(width, height);
        }

        private RConsole(TCODConsole console)
        {
            _console = console;
        }

        public int Width { get { return _console.getWidth(); } }
        public int Height { get { return _console.getHeight(); } }
        public Rectangle Bounds { get { return new Rectangle(0, 0, Width, Height); } }

        public void SetForegroundColour(TCODColor colour)
        {
            _console.setForegroundColor(colour);
        }

        public void SetBackgroundColour(TCODColor colour)
        {
            _console.setBackgroundColor(colour);
        }

        public void SetCharacter(int x, int y, char character)
        {
            SetCharacter(x, y, (int) character);
        }

        public void SetCharacter(int x, int y, int character)
        {
            _console.putChar(x, y, character);
        }

        public void SetCharacter(int x, int y, char character, TCODColor foreground, TCODColor background)
        {
            _console.putCharEx(x, y, character, foreground, background);
        }

        public void SetCharacter(int x, int y, char character, TCODColor foreground)
        {
            SetCharacter(x, y, character, foreground, TCODColor.black);
        }

        public void DrawHorizontalLine(int x, int y, int length)
        {
            _console.hline(x, y, length);
        }

        public void DrawVerticalLine(int x, int y, int length)
        {
            _console.vline(x, y, length);
        }

        public string GetColorControlString(TCODColor colour)
        {
            return GetColorFormat(colour.Red, colour.Green, colour.Blue);
        }

        public string GetStopControl()
        {
            return TCODConsole.getColorControlString(8);
        }

        public void DrawBorder()
        {
            int width = Width;
            int height = Height;
            for (int col = 0; col < width; ++col)
            {
                TCODSpecialCharacter drawCharTop = col == 0
                    ? TCODSpecialCharacter.NW
                    : col == width - 1 ? TCODSpecialCharacter.NE : TCODSpecialCharacter.HorzLine;

                TCODSpecialCharacter drawCharBot = col == 0
                    ? TCODSpecialCharacter.SW
                    : col == width - 1 ? TCODSpecialCharacter.SE : TCODSpecialCharacter.HorzLine;

                SetCharacter(col, 0, (int) drawCharTop);
                SetCharacter(col, 0, (int) drawCharBot);
            }

            for (int row = 1; row < height - 1; ++row)
            {
                SetCharacter(0, row, (int) TCODSpecialCharacter.VertLine);
                SetCharacter(width - 1, row, (int) TCODSpecialCharacter.VertLine);
            }
        }

        public void Clear()
        {
            _console.clear();
        }

        public void PrintString(int x, int y, string text, params object[] args)
        {
            _console.print(x, y, string.Format(text, args));
        }

        public void PrintString(int x, int y, string text, TCODAlignment alignment, params object[] args)
        {
            _console.printEx(x, y, TCODBackgroundFlag.None, alignment, string.Format(text, args));
        }

        public int PrintString(Rectangle rect, string text, params object[] args)
        {
            return _console.printRect(rect.X, rect.Y, rect.Width, rect.Height, string.Format(text, args));
        }

        public int PrintString(Rectangle rect, string text, TCODAlignment alignment, params object[] args)
        {
            return _console.printRectEx(rect.X, rect.Y, rect.Width, rect.Height, TCODBackgroundFlag.None, alignment,
                string.Format(text, args));
        }

        public void Blit(IRConsole src, Rectangle srcRect, int dstX, int dstY, float fgAlpha = 1, float bgAlpha = 1)
        {
            TCODConsole.blit(src.UnderlyingConsole, srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height, _console, dstX, dstY,
                fgAlpha, bgAlpha);
        }

        public TCODConsole UnderlyingConsole { get { return _console; } }

        public void SetBackgroundColour(Rectangle area, TCODColor colour)
        {
            SetBackgroundColour(colour);
            _console.rect(area.X, area.Y, area.Width, area.Height, true);
        }

        public static void InitializeRootConsole(int width, int height)
        {
            TCODConsole.initRoot(width, height, "ProjectR", false, TCODRendererType.GLSL);
            RootConsole = new RConsole(TCODConsole.root);
        }

        public static void Draw()
        {
            TCODConsole.flush();
        }

        public static string GetColorFormat(byte red, byte green, byte blue)
        {
            if (red == 0)
            {
                red = 1;
            }
            if (green == 0)
            {
                green = 1;
            }
            if (blue == 0)
            {
                blue = 1;
            }

            char[] c = Encoding.Default.GetChars(new byte[] { 6, red, green, blue });
            return (string.Format("{0}{1}{2}{3}", c[0], c[1], c[2], c[3]));
        }
    }
}