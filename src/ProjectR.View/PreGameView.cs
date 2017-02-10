using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class PreGameView : ModelState, IRConsole
    {
        public const string MasteryDescription = "Mastery Distribution:\n\n" +
                                                 "  Mastery affects how much damage you\n" +
                                                 "  deal and how much damage you take\n" +
                                                 "  with a certain element.\n\n" +
                                                 "  In general these three scenarios\n" +
                                                 "  are easy to remember:\n\n" +
                                                 "    50 Mastery = Take 200%%, Deal  50%%\n" +
                                                 "   100 Mastery = Take 100%%, Deal 100%%\n" +
                                                 "   150 Mastery = Take  66%%, Deal 150%%\n\n" +
                                                 "  Remember that one point spend here\n" +
                                                 "  does not neccessarily equal one\n" +
                                                 "  point gained in the stats, since\n" +
                                                 "  your race can influence your\n" +
                                                 "  mastery. Switch between Spell view\n" +
                                                 "  and Stat view by pressing the\n" +
                                                 "  Action key.";

        private readonly IAfflictionLister _afflictionLister;
        private readonly ICharDescriptionDrawer _charDescDrawer;

        private readonly IRConsole _console;

        private readonly IMenuDrawer _menuDrawer;
        private readonly ISpellDescriptionDrawer _normAttackDrawer;
        private readonly ISpellDescriptionDrawer _spell1Drawer;
        private readonly ISpellDescriptionDrawer _spell2Drawer;
        private readonly ISpellDescriptionDrawer _spell3Drawer;
        private readonly ISpellDescriptionDrawer _spell4Drawer;
        private readonly IStatScreenDrawer _statScreenDrawer;


        public PreGameView()
        {
            _console = new RConsole(39, 61);
            _menuDrawer = new MenuDrawer();
            _charDescDrawer = new CharDescriptionDrawer();
            _statScreenDrawer = new StatScreenDrawer();
            _normAttackDrawer = new SpellDescriptionDrawer();
            _afflictionLister = new AfflictionLister();
            _spell1Drawer = new SpellDescriptionDrawer();
            _spell2Drawer = new SpellDescriptionDrawer();
            _spell3Drawer = new SpellDescriptionDrawer();
            _spell4Drawer = new SpellDescriptionDrawer();

            _charDescDrawer.SetPosition(43, 3);
            _statScreenDrawer.SetPosition(80, 3);
            _normAttackDrawer.SetPosition(43, 35);
            _afflictionLister.SetPosition(80, 35);

            _spell1Drawer.SetPosition(43, 3);
            _spell2Drawer.SetPosition(80, 3);
            _spell3Drawer.SetPosition(43, 35);
            _spell4Drawer.SetPosition(80, 35);
        }

        public override void Run()
        {
            Clear();
            DrawBorder();
            PrintString(1, 16, MasteryDescription);
            PrintString(1, 38,
                string.Format("Available points to distribute: {0}", Model.PreGameModel.AvailableMasteryPoints));
            RConsole.RootConsole.Blit(this, Bounds, 2, 3);
            var menu = Model.MenuModel.ActiveMenu;
            _menuDrawer.DrawMenuPart(menu, 0, 5, 3, 4, 1);
            _menuDrawer.DrawMenuPart(menu, 6, 14, 3, 43, 1);
            _menuDrawer.DrawMenuPart(menu, 15, 15, 3, 63);

            var character = Model.PreGameModel.Character;

            if (Model.PreGameModel.ShowStats)
            {
                _charDescDrawer.DrawSummary(character);
                _statScreenDrawer.DrawStats(character);
                _normAttackDrawer.DrawSpellDescription(character.Spells[0]);
                _afflictionLister.ListAfflictions(character, Model);
            }
            else
            {
                _spell1Drawer.DrawSpellDescription(character.Spells[2]);
                _spell2Drawer.DrawSpellDescription(character.Spells[3]);
                _spell3Drawer.DrawSpellDescription(character.Spells[4]);
                _spell4Drawer.DrawSpellDescription(character.Spells[5]);
            }
        }

        #region IRConsole delegation

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

        public int Width { get { return _console.Width; } }

        public int Height { get { return _console.Height; } }

        public Rectangle Bounds { get { return _console.Bounds; } }

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

        #endregion
    }
}