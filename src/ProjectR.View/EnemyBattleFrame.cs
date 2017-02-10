using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.View
{
    public class EnemyBattleFrame : CharBattleFrame
    {
        protected override void DrawMP()
        {
            CachedMP = (int) CurrentChar.CurrentMP;
            CharConsole.PrintString(6, 8, "         ");

            var percentage = CachedMP / CurrentChar.Stats.GetTotalStat(BaseStat.MP);
            var colour = new TCODColor((float) (205d * percentage), 1f, 1f);
            var colourControl = CharConsole.GetColorControlString(colour);

            CharConsole.PrintString(14, 8, "{0}{1}{2}", TCODAlignment.RightAlignment, colourControl, (percentage * 100d).ToString("F2"),
                CharConsole.GetStopControl());
        }

        protected override void DrawHP()
        {
            CharConsole.PrintString(6, 6, "         ");
            var currentHP = CurrentChar.CurrentHP;
            var percentage = currentHP / CurrentChar.Stats.GetTotalStat(BaseStat.HP);
            if (percentage > 1d)
            {
                CurrentChar.Heal(currentHP);
                CurrentChar.ResetDamageTaken();
            }

            var colour = new TCODColor((float) (120d * percentage), 1f, 1f);
            var colourControl = CharConsole.GetColorControlString(colour);
            CharConsole.PrintString(14, 6, "{0}{1}%%{2}", TCODAlignment.RightAlignment, colourControl, (percentage * 100d).ToString("F2"),
                CharConsole.GetStopControl());
        }

        protected override void DrawName()
        {
            var colour = Strength.GetAssociatedColour();
            var colourControl = CharConsole.GetColorControlString(colour);

            CachedName = CurrentChar.Name;
            CharConsole.PrintString(new Rectangle(8, 1, 13, 2), "                          ",
                TCODAlignment.CenterAlignment);
            CharConsole.PrintString(new Rectangle(8, 1, 13, 2), "{0}{1}{2}", TCODAlignment.CenterAlignment,
                colourControl, CachedName, CharConsole.GetStopControl());
        }
    }
}