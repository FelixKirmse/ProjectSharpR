using System.Drawing;
using System.Text;
using libtcod;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class BattleLogDrawer : ModelState
    {
        private IBattleLog _log;
        private readonly IRConsole _logConsole;
        private Point _position;
        private IRConsole _root;
        private readonly StringBuilder _logBuilder;
        public const int MaxLogLines = 25;
        private readonly Rectangle _logArea;

        public BattleLogDrawer()
        {
            _logConsole = new RConsole(37, 29);
            _logArea = new Rectangle(1, 3, _logConsole.Width - 2, _logConsole.Height - 3);
            _logBuilder = new StringBuilder();
        }

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public override void Activate()
        {
            _log = Model.BattleModel.BattleLog;
            _root = RConsole.RootConsole;
            _log.ClearLog();
        }

        public override void Run()
        {
            var fetchCount = 5;
            var printedLines = 0;

            do
            {
                _logConsole.Clear();
                var redControl = _logConsole.GetColorControlString(TCODColor.red);
                var greenControl = _logConsole.GetColorControlString(TCODColor.green);
                var stopControl = _logConsole.GetStopControl();

                _logConsole.PrintString(1, 1, "{0}Battlelog:{1}", redControl, stopControl);
                _logConsole.DrawBorder();

                var log = _log.GetLastEntries(fetchCount);
                printedLines = 0;

                foreach (var logEntry in log)
                {
                    _logBuilder.Clear();
                    var printArea = new Rectangle(_logArea.X, _logArea.Y + printedLines, _logArea.Width,
                        _logArea.Height - printedLines);
                    if (logEntry.IsCustomMessage)
                    {
                        _logBuilder.AppendLine(logEntry.CustomMessage).AppendLine();
                        printedLines += _logConsole.PrintString(printArea, _logBuilder.ToString());
                        continue;
                    }

                    _logBuilder.AppendFormat("{0}{1}{2} uses {3} on {4}{5}{6}",
                        logEntry.CasterIsEnemy ? redControl : greenControl, logEntry.CasterName, stopControl,
                        logEntry.SpellName, logEntry.ReceiverIsEnemy ? redControl : greenControl,
                        logEntry.SelfCast ? "self" : logEntry.ReceiverName, stopControl);

                    if (logEntry.AttackDodged)
                    {
                        _logBuilder.Append(" but the attack was dodged");
                    }
                    else
                    {
                        _logBuilder.Append(logEntry.WasHealed ? " healing for " : " dealing ")
                                   .Append(logEntry.WasHealed ? greenControl : redControl)
                                   .Append(logEntry.Value <= 0d ? "no" : RHelper.SanitizeNumber(logEntry.Value))
                                   .Append(stopControl)
                                   .Append(logEntry.WasHealed ? " healing" : " damage");
                    }

                    if (logEntry.AttackBlocked)
                    {
                        _logBuilder.Append(" (blocked)");
                    }

                    if (logEntry.WasAfflicted)
                    {
                        _logBuilder.Append(" and inflicting ")
                                   .Append(logEntry.AfflictedBy);
                    }

                    _logBuilder.Append("!");

                    if (logEntry.Fatal)
                    {
                        _logBuilder.AppendLine()
                                   .AppendLine()
                                   .Append(logEntry.ReceiverName)
                                   .AppendLine(" dies!");
                    }

                    printedLines += _logConsole.PrintString(printArea, _logBuilder.ToString());
                }
                --fetchCount;
            } while (printedLines > MaxLogLines);
            _root.Blit(_logConsole, _logConsole.Bounds, _position.X, _position.Y);
        }
    }
}