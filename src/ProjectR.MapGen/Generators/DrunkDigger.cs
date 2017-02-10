using System.Drawing;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen.Generators
{
    public class DrunkDigger : Generator
    {
        public DrunkDigger(int minWidth, int minHeight, int maxWidth, int maxHeight, IRMap map)
            : base(minWidth, minHeight, maxWidth, maxHeight, map)
        {
        }

        public override void GenerateImpl(int row, int col, Direction dir)
        {
            var topRow = row;
            var leftCol = col;
            GetTopLeftCorner(ref topRow, ref leftCol, dir);

            var goalRow = row;
            var goalCol = col;
            RHelper.MoveInDirection(ref goalRow, ref goalCol, dir);

            var digArea = new Rectangle(leftCol + 1, topRow + 1, Width - 2, Height - 2);
            var digger = new Digger(goalRow, goalCol, (int) ((digArea.Width * digArea.Height) / 25d), Map);
            Map[row, col] = Map[row, col].Is(RCell.Important)
                ? RCell.Door | RCell.Important | RCell.Closed
                : RCell.Floor;
            digger.DigCell(row, col);
            digger.DigCell(row + 1, col);
            digger.DigCell(row - 1, col);
            digger.DigCell(row, col + 1);
            digger.DigCell(row, col - 1);
            digger.Dig();
        }

        public class Digger
        {
            private readonly ulong _combatBonus;
            private readonly bool _darkDigger;
            private readonly int _digGoal;
            private readonly bool _doubleCombatBonus;
            private readonly IRMap _map;
            private int _col;
            private int _digged;
            private int _row;

            public Digger(int row, int col, int digGoal, IRMap map)
            {
                _row = row;
                _col = col;
                _digGoal = digGoal;
                _map = map;
                _digged = 0;
                _darkDigger = RHelper.RollPercentage(25);
                _doubleCombatBonus = RHelper.RollPercentage(10);
                _combatBonus = (ulong) RHelper.Roll(0, 23);
            }


            public void DigCell(int row, int col)
            {
                var cell = _map[row, col];
                if (cell.Is(RCell.Important))
                {
                    return;
                }

                if (cell.Is(RCell.Diggable | RCell.Door))
                {
                    cell = _darkDigger ? RCell.Wall | RCell.Dark : RCell.Wall;
                }

                cell = cell.InsertCombatBonus(_combatBonus);

                if (_doubleCombatBonus)
                {
                    cell |= RCell.DoubleCombatBonus;
                }

                _map[row, col] = cell;
            }

            public void Dig()
            {
                DigOut();

                do
                {
                    var dir = RHelper.GetRandomDirection();
                    var nextRow = _row;
                    var nextCol = _col;
                    RHelper.MoveInDirection(ref nextRow, ref nextCol, dir);

                    if (!CanMove(nextRow, nextCol))
                    {
                        continue;
                    }

                    _row = nextRow;
                    _col = nextCol;

                    if (!CanDig())
                    {
                        continue;
                    }

                    DigOut();
                    ++_digged;
                } while (_digged < _digGoal);
            }

            private bool CanDig()
            {
                return _map[_row, _col].Is(RCell.Diggable | RCell.Wall);
            }

            private bool CanMove(int row, int col)
            {
                return !_map[row, col].Is(RCell.Important);
            }

            private void DigOut()
            {
                var cell = _darkDigger ? RCell.Floor | RCell.Dark : RCell.Floor;
                cell = cell.InsertCombatBonus(_combatBonus);

                if (_doubleCombatBonus)
                {
                    cell |= RCell.DoubleCombatBonus;
                }

                _map[_row, _col] = cell;

                DigCell(_row, _col + 1);
                DigCell(_row, _col - 1);
                DigCell(_row + 1, _col);
                DigCell(_row - 1, _col);
            }
        }
    }
}