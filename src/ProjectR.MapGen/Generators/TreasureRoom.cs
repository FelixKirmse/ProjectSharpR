using System;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen.Generators
{
    public class TreasureRoom : Generator
    {
        private readonly RandomContainer<RCell> _rarities = new RandomContainer<RCell>
        {
            { RCell.Uncommon, 600 },
            { RCell.Rare, 200 },
            { RCell.Epic, 50 },
            { RCell.Legendary, 10 },
            { RCell.Artifact, 1 }
        };

        private readonly RandomContainer<RCell> _sizes = new RandomContainer<RCell>
        {
            { RCell.Normal, 20 },
            { RCell.Small, 75 },
            { RCell.Big, 4 },
            { RCell.Grand, 1 }
        };

        public TreasureRoom(int minWidth, int minHeight, int maxWidth, int maxHeight, IRMap map)
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
                    if (r == topRow || c == leftCol || r == maxRow - 1 || c == maxCol - 1)
                    {
                        Map[r, c] = RCell.Wall | RCell.Important;
                    }
                    else
                    {
                        Map[r, c] = RCell.Floor;
                    }
                }
            }

            var treasureCount = (int) Math.Sqrt(Width * Height);

            for (var i = 0; i < treasureCount; ++i)
            {
                int chestRow;
                int chestCol;
                do
                {
                    chestRow = RHelper.Roll(topRow + 1, maxRow - 2);
                    chestCol = RHelper.Roll(leftCol + 1, maxCol - 2);
                } while (Map[chestRow, chestCol].Is(RCell.Chest));

                Map[chestRow, chestCol] |= RCell.Chest | _rarities.Get() | _sizes.Get();
            }

            if (dir != Direction.Center)
            {
                Map[row, col] = RCell.Door | RCell.Locked | RCell.Closed;
            }
        }
    }
}