using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.View
{
    public class PlayerBattleFrame : CharBattleFrame
    {
        protected override void DrawMP()
        {
            CachedMP = (int) CurrentChar.CurrentMP;
            CharConsole.PrintString(6, 8, "        ");

            var percentage = CachedMP / 200f;
            var colour = new TCODColor(205f * percentage, 1f, 1f);
            var colourControl = CharConsole.GetColorControlString(colour);
            CharConsole.PrintString(14, 8, "{0}{1}{2}", TCODAlignment.RightAlignment, colourControl, CachedMP, CharConsole.GetStopControl());
        }

        protected override void DrawHP()
        {
            CharConsole.PrintString(6, 6, "         ");
            var currentHP = CurrentChar.CurrentHP;
            var percentage = currentHP / CurrentChar.Stats.GetTotalStat(BaseStat.HP);
            var colour = new TCODColor((float) (120d * percentage), 1f, 1f);
            var colourControl = CharConsole.GetColorControlString(colour);
            CharConsole.PrintString(14, 6, "{0}{1}{2}", TCODAlignment.RightAlignment, colourControl, RHelper.SanitizeNumber(currentHP), CharConsole.GetStopControl());
        }

        protected override void DrawName()
        {
            CachedName = CurrentChar.Name;
            CharConsole.PrintString(new Rectangle(8, 1, 13, 2), "                          ", TCODAlignment.CenterAlignment);
            CharConsole.PrintString(new Rectangle(8, 1, 13, 2), CachedName, TCODAlignment.CenterAlignment);
        }
    }
}