using System;
using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public abstract class CharBattleFrame : ICharBattleFrame
    {
        private readonly IRConsole _root;
        private Point _position;
        protected IRConsole CharConsole { get; set; }
        protected ICharacter CurrentChar { get; set; }
        protected string CachedName { get; set; }
        protected int CachedMP { get; set; }
        protected MobPackStrength Strength { get; set; }

        protected CharBattleFrame()
        {
            _position = new Point();
            CharConsole = new RConsole(16, 10);
            _root = RConsole.RootConsole;
            DrawStatics();
        }

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public void AssignCharacter(ICharacter character, MobPackStrength strength = MobPackStrength.Equal)
        {
            CurrentChar = character;
            Strength = strength;
        }

        public void Draw()
        {
            DrawBorder();

            if (CachedName != CurrentChar.Name)
            {
                DrawName();
            }

            DrawTurn();
            DrawHP();

            if (Math.Abs(CachedMP - CurrentChar.CurrentMP) > 0.001d)
            {
                DrawMP();
            }

            _root.Blit(CharConsole, CharConsole.Bounds, _position.X, _position.Y);
        }

        private void DrawStatics()
        {
            CharConsole.SetBackgroundColour(TCODColor.black);
            CharConsole.SetForegroundColour(TCODColor.white);
            CharConsole.PrintString(new Rectangle(1, 4, 5, 5), "Turn:\n\nHP  :\n\nMP  :");
        }

        public static ICharBattleFrame CreateFrameForPlayerChar()
        {
            return new PlayerBattleFrame();
        }

        public static ICharBattleFrame CreateFrameForEnemyChar()
        {
            return new EnemyBattleFrame();
        }

        protected abstract void DrawMP();

        protected abstract void DrawHP();

        private void DrawTurn()
        {
            CharConsole.PrintString(6, 4, "    ");
            var percentage = CurrentChar.TurnCounter / CurrentChar.TimeToAction;
            var colour = new TCODColor(CurrentChar.TakesTurn ? 0f : 30f, 1f, 1f);
            var colourControl = CharConsole.GetColorControlString(colour);
            CharConsole.PrintString(14, 4,
                string.Format("{0}{1}%{2}", colourControl,
                    CurrentChar.TakesTurn ? 100d.ToString("F2") : (percentage * 100d).ToString("F2"),
                    CharConsole.GetStopControl()), TCODAlignment.RightAlignment);
        }

        protected abstract void DrawName();

        private void DrawBorder()
        {
            CharConsole.SetForegroundColour(CurrentChar.IsMarked && CurrentChar.TakesTurn
                ? TCODColor.orange
                : CurrentChar.IsMarked ? TCODColor.red : CurrentChar.TakesTurn ? TCODColor.green : TCODColor.white);
            CharConsole.DrawBorder();
            CharConsole.SetForegroundColour(TCODColor.white);
        }
    }
}