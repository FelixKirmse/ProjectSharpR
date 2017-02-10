using System;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen.Generators
{
    public class HallwayGenerator : Generator
    {
        public HallwayGenerator(int minWidth, int minHeight, int maxWidth, int maxHeight, IRMap map)
            : base(minWidth, minHeight, maxWidth, maxHeight, map)
        {
        }

        public override void GenerateImpl(int row, int col, Direction dir)
        {
            var topRow = row;
            var leftCol = col;

            var length = Math.Max(Width, Height);

            if (dir == Direction.West || dir == Direction.East)
            {
                Height = 3;
                Width = length;
            }

            if (dir == Direction.South || dir == Direction.North)
            {
                Width = 3;
                Height = length;
            }

            GetTopLeftCorner(ref topRow, ref leftCol, dir);

            var maxRow = topRow + Height;
            var maxCol = leftCol + Width;
            for (var r = topRow; r < maxRow; ++r)
            {
                for (var c = leftCol; c < maxCol; ++c)
                {
                    var cell = Map[r, c];
                    if (r == row && c == col)
                    {
                        if (cell.Is(RCell.Important))
                        {
                            cell = RCell.Door | RCell.Important | RCell.Closed;
                        }
                        else
                        {
                            cell = RCell.Floor | RCell.Corridor;
                        }
                    }
                    else if (r == topRow || c == leftCol || r == maxRow - 1 || c == maxCol - 1)
                    {
                        cell = RCell.Wall | RCell.Corridor;
                    }
                    else
                    {
                        cell = RCell.Floor | RCell.Corridor;
                    }
                    Map[r, c] = cell;
                }
            }
        }
    }
}