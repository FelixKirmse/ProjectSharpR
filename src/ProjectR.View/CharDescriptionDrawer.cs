using System.Drawing;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class CharDescriptionDrawer : RConsole, ICharDescriptionDrawer
    {
        private int _posX;
        private int _posY;

        public CharDescriptionDrawer()
            : base(37, 32)
        {
        }

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public void DrawSummary(ICharacter character, IRConsole target = null)
        {
            if (character == null)
            {
                return;
            }

            var targetConsole = target ?? RootConsole;

            Clear();
            DrawBorder();
            PrintString(1, 1, "Name:");
            PrintString(4, 3, character.Name);
            PrintString(1, 5, "Race:");
            PrintString(4, 7, character.Race);
            PrintString(1, 9, "Lore:");
            PrintString(new Rectangle(4, 11, 32, 11), character.Lore);
            targetConsole.Blit(this, Bounds, _posX, _posY);
        }
    }
}