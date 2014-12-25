using System;
using System.Drawing;
using System.Linq;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class MenuDrawer : IMenuDrawer
    {
        private readonly RConsole _menuConsole;
        private Rectangle _heatZone;

        public MenuDrawer()
        {
            _menuConsole = new RConsole(RConsole.RootConsole.Width, RConsole.RootConsole.Height);
            _menuConsole.SetBackgroundColour(TCODColor.black);
            _menuConsole.SetForegroundColour(TCODColor.white);
            _heatZone = new Rectangle();
        }

        public void DrawMenu(IMenu menu, int row, int col, int offset = 0)
        {
            DrawMenu(menu, row, col, offset, null, 0, menu.GetStateCount() - 1);
        }

        public void DrawMenu(IMenu menu, IRConsole target, int row = 0, int col = 0, int offset = 0)
        {
            DrawMenu(menu, row, col, offset, target, 0, menu.GetStateCount() - 1);
        }

        public void DrawMenuPart(IMenu menu, int startItem, int endItem, int row = 0, int col = 0, int offset = 0)
        {
            DrawMenu(menu, row, col, offset, null, startItem, endItem);
        }

        public void DrawMenu(IMenu menu, int row, int col, int offset, IRConsole target, int startItem, int endItem)
        {
            if (menu == null)
            {
                return;
            }

            _menuConsole.Clear();
            IRConsole targetConsole = target ?? RConsole.RootConsole;

            int rightMostCol = 0;
            int itemCount = endItem + 1 - startItem;
            int counter = 0;
            int newLineCount = 0;
            for (int i = startItem; i <= endItem; ++i, ++counter)
            {
                int printRow = counter + counter * offset;
                IMenuItem item = menu.GetMenuItem(i);
                string label = item.Label;
                int labelLength = Measure(label);
                newLineCount += label.Count(x => x == '\n');
                if (labelLength > rightMostCol)
                {
                    rightMostCol = labelLength;
                }

                if (item.IsSelected)
                {
                    _menuConsole.SetForegroundColour(TCODColor.red);
                }
                else if (item.IsDisabled)
                {
                    _menuConsole.SetForegroundColour(TCODColor.grey);
                }
                else
                {
                    _menuConsole.SetForegroundColour(TCODColor.white);
                }

                _menuConsole.PrintString(0, printRow, label);
            }

            _heatZone.Width = rightMostCol;
            _heatZone.Height = itemCount + (offset * itemCount) + newLineCount;

            targetConsole.Blit(_menuConsole, _heatZone, row, col);
        }

        private static int Measure(string str)
        {
            if (str.IndexOf('\n') != -1)
            {
                return str.Length;
            }

            int firstLineLength = str.IndexOf('\n');
            int secondLineLength = str.IndexOf('\n', firstLineLength) - firstLineLength;
            int thirdLineLength = str.Length - 2 - secondLineLength - firstLineLength;

            return Math.Max(thirdLineLength, Math.Max(firstLineLength, secondLineLength));
        }
    }
}