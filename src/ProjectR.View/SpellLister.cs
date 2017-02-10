using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class SpellLister : RConsole, ISpellLister
    {
        private int _posX;
        private int _posY;

        public SpellLister()
            : base(37, 29)
        {
        }

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public void Draw(ICharacter character, IRConsole target = null)
        {
            var targetConsole = target ?? RootConsole;
            Clear();
            DrawBorder();
            var redControl = GetColorControlString(TCODColor.red);
            PrintString(1, 1, "{0}Spelllist:{1}", redControl, GetStopControl());

            var row = 1;
            foreach (var spell in character.Spells)
            {
                row += 2;
                PrintString(1, row, spell.Name);
            }
            targetConsole.Blit(this, Bounds, _posX, _posY);
        }
    }
}