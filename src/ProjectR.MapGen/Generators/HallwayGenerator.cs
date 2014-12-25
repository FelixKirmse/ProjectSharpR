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
            int topRow = row;
            int leftCol = col;

            int length = Math.Max(Width, Height);

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

            int maxRow = topRow + Height;
            int maxCol = leftCol + Width;
            for (int r = topRow; r < maxRow; ++r)
            {
                for (int c = leftCol; c < maxCol; ++c)
                {
                    RCell cell = Map[r, c];
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