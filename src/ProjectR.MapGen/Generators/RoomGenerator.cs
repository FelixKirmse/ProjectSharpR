using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen.Generators
{
    public class RoomGenerator : Generator
    {
        public RoomGenerator(int minWidth, int minHeight, int maxWidth, int maxHeight, IRMap map)
            : base(minWidth, minHeight, maxWidth, maxHeight, map)
        {
        }

        public override void GenerateImpl(int row, int col, Direction dir)
        {
            var topRow = row;
            var leftCol = col;
            GetTopLeftCorner(ref topRow, ref leftCol, dir);

            var maxRow = topRow + Height;
            var maxCol = leftCol + Width;

            for (var r = topRow; r < maxRow; ++r)
            {
                for (var c = leftCol; c < maxCol; ++c)
                {
                    var cell = Map[r, c];
                    if (r == topRow || c == leftCol || r == maxRow - 1 || c == maxCol - 1)
                    {
                        if (cell.Is(RCell.Wall) &&
                            !cell.Is(RCell.Important) &&
                            !((r == topRow && c == leftCol) || (r == topRow && c == maxCol - 1) ||
                              (r == maxRow - 1 && c == leftCol) || (r == maxRow - 1 && c == maxCol - 1)))
                        {
                            cell = RCell.Floor;
                        }
                        else
                        {
                            cell = RCell.Wall | RCell.Important;
                        }
                    }
                    else
                    {
                        cell = RCell.Floor;
                    }

                    Map[r, c] = cell;
                }
            }

            var entranceCell = Map[row, col];
            if (entranceCell.Is(RCell.Wall))
            {
                Map[row, col] = RCell.Door | RCell.Closed;
            }
        }
    }
}