using System.Drawing;
using System.Linq;
using System.Text;
using libtcod;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class SpellDescriptionDrawer : RConsole, ISpellDescriptionDrawer
    {
        private Point _position;
        private readonly Rectangle _printArea;

        public SpellDescriptionDrawer()
            : base(37, 29)
        {
            _position = new Point();
            _printArea = new Rectangle(1, 18, Width - 2, Height - 19);
        }

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public void DrawSpellDescription(ISpell spell, IRConsole target = null)
        {
            var targetConsole = target ?? RootConsole;
            Clear();
            DrawBorder();
            PrintString(1, 1, string.Format("{0}Name:{1}", GetColorControlString(TCODColor.red), GetStopControl()));
            PrintString(1, 3, spell.Name);
            PrintString(1, 6, "{0}Type:{1}", GetColorControlString(TCODColor.red), GetStopControl());

            var type = new StringBuilder();
            switch (spell.SpellType)
            {
                case SpellType.Physical:
                    type.Append("Physical ");
                    break;

                case SpellType.Magical:
                    type.Append("Magical ");
                    break;

                case SpellType.Composite:
                    type.Append("Composite ");
                    break;

                case SpellType.Pure:
                    type.Append("Pure ");
                    break;
            }

            switch (spell.TargetType)
            {
                case TargetType.Single:
                    type.Append("Single Target ");
                    break;

                case TargetType.Myself:
                    type.Append("Self-cast ");
                    break;

                case TargetType.Allies:
                    type.Append("Ally AoE ");
                    break;

                case TargetType.Enemies:
                    type.Append("Enemy AoE ");
                    break;

                case TargetType.Decaying:
                    type.Append("Proximity-based ");
                    break;
            }

            type.Append(spell.IsSupportSpell ? "Support Spell" : "Spell");
            PrintString(new Rectangle(1, 8, 32, 2), type.ToString());
            PrintString(1, 11, "{0}Masteries:{1}", GetColorControlString(TCODColor.red), GetStopControl());

            var masteries = new StringBuilder();
            foreach (var mastery in spell.Masteries.Select(eleMastery => (Stat) eleMastery))
            {
                masteries.Append(mastery.GetString()).Append(" ");
            }

            if (spell.Masteries.Count == 0)
            {
                masteries.Append("None");
            }

            PrintString(new Rectangle(1, 13, 32, 2), masteries.ToString());
            PrintString(_printArea, spell.Description);
            targetConsole.Blit(this, Bounds, _position.X, _position.Y);
        }
    }
}