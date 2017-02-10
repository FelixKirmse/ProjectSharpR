using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public abstract class InitializeableModelStateWithConsole : InitializeableModelState, IRConsole
    {
        private readonly IRConsole _console;

        protected InitializeableModelStateWithConsole(int width, int height)
        {
            _console = new RConsole(width, height);
        }

        public int Width { get { return _console.Width; } }

        public int Height { get { return _console.Height; } }

        public Rectangle Bounds { get { return _console.Bounds; } }

        public void SetForegroundColour(TCODColor colour)
        {
            _console.SetForegroundColour(colour);
        }

        public void SetBackgroundColour(TCODColor colour)
        {
            _console.SetBackgroundColour(colour);
        }

        public void SetBackgroundColour(Rectangle area, TCODColor colour)
        {
            _console.SetBackgroundColour(area, colour);
        }

        public void SetCharacter(int x, int y, char character)
        {
            _console.SetCharacter(x, y, character);
        }

        public void SetCharacter(int x, int y, int character)
        {
            _console.SetCharacter(x, y, character);
        }

        public void SetCharacter(int x, int y, char character, TCODColor foreground, TCODColor background)
        {
            _console.SetCharacter(x, y, character, foreground, background);
        }

        public void SetCharacter(int x, int y, char character, TCODColor foreground)
        {
            _console.SetCharacter(x, y, character, foreground);
        }

        public void DrawHorizontalLine(int x, int y, int length)
        {
            _console.DrawHorizontalLine(x, y, length);
        }

        public void DrawVerticalLine(int x, int y, int length)
        {
            _console.DrawVerticalLine(x, y, length);
        }

        public void Blit(IRConsole src, Rectangle srcRect, int dstX, int dstY, float fgAlpha = 1, float bgAlpha = 1)
        {
            _console.Blit(src, srcRect, dstX, dstY, fgAlpha, bgAlpha);
        }

        public TCODConsole UnderlyingConsole { get { return _console.UnderlyingConsole; } }

        public string GetColorControlString(TCODColor colour)
        {
            return _console.GetColorControlString(colour);
        }

        public void DrawBorder()
        {
            _console.DrawBorder();
        }

        public void Clear()
        {
            _console.Clear();
        }

        public void PrintString(int x, int y, string text, params object[] args)
        {
            _console.PrintString(x, y, text, args);
        }

        public void PrintString(int x, int y, string text, TCODAlignment alignment, params object[] args)
        {
            _console.PrintString(x, y, text, alignment, args);
        }

        public int PrintString(Rectangle rect, string text, TCODAlignment alignment, params object[] args)
        {
            return _console.PrintString(rect, text, alignment, args);
        }

        public int PrintString(Rectangle rect, string text, params object[] args)
        {
            return _console.PrintString(rect, text, args);
        }

        public string GetStopControl()
        {
            return _console.GetStopControl();
        }
    }
}