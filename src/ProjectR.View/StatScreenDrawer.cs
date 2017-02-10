using System;
using System.Drawing;
using System.Text;
using libtcod;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class StatScreenDrawer : RConsole, IStatScreenDrawer
    {
        private static readonly Rectangle StatRectangle = new Rectangle(7, 9, 17, 9);
        private static readonly Rectangle StatStrengthRect = new Rectangle(29, 9, 17, 9);
        private static readonly Rectangle MasteryRect = new Rectangle(7, 22, 4, 9);
        private static readonly Rectangle MasteryStrengthRect = new Rectangle(13, 22, 4, 9);
        private static readonly Rectangle ResiRect = new Rectangle(26, 22, 2, 4);
        private static readonly Rectangle ResiStrengthRect = new Rectangle(29, 22, 4, 4);

        private Point _position;

        public StatScreenDrawer()
            : base(37, 32)
        {
            _position = new Point();
        }

        public void DrawStats(ICharacter character, IRConsole targetConsole = null)
        {
            var target = targetConsole ?? RootConsole;
            Clear();
            SetupStatics();
            PrintString(35, 1, string.Format("Level: {0}", character.CurrentLevel), TCODAlignment.RightAlignment);
            PrintString(23, 30, character.Stats.EVAType == EVAType.Dodge ? "Dodge" : "Block");
            PrintString(4, 2, character.Name);
            PrintString(4, 5, character.Race);

            var stats = character.Stats;
            var statFormat = new StringBuilder();
            statFormat.AppendFormat("{0} / {1}\n", RHelper.SanitizeNumber(character.CurrentHP),
                RHelper.SanitizeNumber(stats.GetTotalStat(BaseStat.HP)));
            statFormat.AppendFormat("{0} / {1}\n", character.CurrentMP, 200);

            var statStrengthFormat = new StringBuilder();
            var hpPercentage = (float) (character.CurrentHP / stats.GetTotalStat(BaseStat.HP));
            var mpPercentage = (float) (character.CurrentMP / 200d);

            var stopControl = GetColorControlString(TCODColor.white);
            //var stopControl = TCODConsole.getColorControlString(8);

            statStrengthFormat.AppendFormat("{0}{1}%%{2}\n",
                GetColorControlString(new TCODColor(120f * hpPercentage, 1f, 1f)),
                (hpPercentage * 100d).ToString("F0"), stopControl);

            statStrengthFormat.AppendFormat("{0}{1}%%{2}\n",
                GetColorControlString(new TCODColor(205f * mpPercentage, 1f, 1f)),
                (mpPercentage * 100d).ToString("F0"), stopControl);

            for (var stat = Stat.AD; stat <= Stat.CHA; ++stat)
            {
                statFormat.AppendFormat("{0}\n", RHelper.SanitizeNumber(stats.GetTotalStat(stat)));
                statStrengthFormat.AppendFormat("{0}{1}%%{2}\n", GetColor(stats, stat),
                    (stats[stat][StatType.BattleMod] * 100d).ToString("F0"), stopControl);
            }

            PrintString(StatRectangle, statFormat.ToString().TrimEnd());
            PrintString(StatStrengthRect, statStrengthFormat.ToString().TrimEnd());

            var masteryFormat = new StringBuilder();
            var masteryStrengthFormat = new StringBuilder();

            for (var stat = Stat.FIR; stat <= Stat.LGT; ++stat)
            {
                masteryFormat.AppendFormat("{0}\n", (int) stats.GetTotalStat(stat));
                masteryStrengthFormat.AppendFormat("{0}{1}%%{2}\n",
                    GetColor(stats, stat), (int) (stats[stat][StatType.BattleMod] * 100d), stopControl);
            }

            PrintString(MasteryRect, masteryFormat.ToString().TrimEnd());
            PrintString(MasteryStrengthRect, masteryStrengthFormat.ToString().TrimEnd());

            var resiFormat = new StringBuilder();
            var resiStrengthFormat = new StringBuilder();

            for (var stat = Stat.PSN; stat <= Stat.SIL; ++stat)
            {
                if (stat == Stat.SLW || stat == Stat.STD)
                {
                    continue;
                }

                resiFormat.AppendFormat("{0}\n", (int) stats.GetTotalStat(stat));
                resiStrengthFormat.AppendFormat("{0}{1}%%{2}\n", GetColor(stats, stat),
                    (int) (stats[stat][StatType.BattleMod] * 100d), stopControl);
            }

            PrintString(ResiRect, resiFormat.ToString().TrimEnd());
            PrintString(ResiStrengthRect, resiStrengthFormat.ToString().TrimEnd());

            target.Blit(this, Bounds, _position.X, _position.Y);
        }

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }

        private string GetColor(IStats stats, Stat stat)
        {
            var value = stats[stat][StatType.BattleMod] * 100d;
            return Math.Abs(value - 100d) < 0.001d
                ? GetColorControlString(TCODColor.white)
                : value > 100 ? GetColorControlString(TCODColor.green) : GetColorControlString(TCODColor.red);
        }

        private void SetupStatics()
        {
            DrawBorder();
            PrintString(1, 1, "Name:");
            PrintString(1, 4, "Race:");
            PrintString(1, 7, "Stats:");
            PrintString(27, 7, "Strength:");
            PrintString(new Rectangle(2, 9, 4, 9), "HP :\nMP :\nAD :\nMD :\nDEF:MR :\nEVA:SPD:CHA:");
            PrintString(1, 20, "Masteries:");
            PrintString(20, 20, "Resistances:");
            PrintString(20, 28, "Type of EVA:");
            PrintString(new Rectangle(2, 22, 4, 9), "FIR:WAT:ICE:ARC:WND:HOL:DRK:GRN:LGT:");
            PrintString(new Rectangle(21, 22, 4, 4), "PSN:PAR:DTH:SIL:");
        }
    }
}