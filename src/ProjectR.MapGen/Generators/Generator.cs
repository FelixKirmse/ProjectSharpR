using System.Diagnostics;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen.Generators
{
    public abstract class Generator : IGenerator
    {
        private int _height;
        private IMobPackManager _packManager;
        private int _spawnChance;
        private bool _spawningEnabled;
        private int _width;
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public int OffsetX { get; private set; }
        public int OffsetY { get; private set; }

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value.MakeOdd();
                OffsetX = (int) (_width / 2d);
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value.MakeOdd();
                OffsetY = (int) (_height / 2d);
            }
        }

        public IRMap Map { get; set; }

        protected Generator(int minWidth, int minHeight, int maxWidth, int maxHeight, IRMap map)
        {
            MinWidth = minWidth;
            MinHeight = minHeight;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Map = map;
        }

        public bool Generate(int row, int col, Direction direction)
        {
            Width = RHelper.Roll(MinWidth, MaxWidth);
            Height = RHelper.Roll(MinHeight, MaxHeight);

            if (!CheckAvailableSpace(row, col, direction))
            {
                return false;
            }

            GenerateImpl(row, col, direction);

            if (!_spawningEnabled || !RHelper.RollPercentage(_spawnChance))
            {
                return true;
            }

            var topRow = row;
            var leftCol = col;
            GetTopLeftCorner(ref topRow, ref leftCol, direction);

            var maxRow = topRow + Height;
            var maxCol = leftCol + Width;

            int spawnRow;
            int spawnCol;

            do
            {
                spawnRow = RHelper.Roll(topRow, maxRow);
                spawnCol = RHelper.Roll(leftCol, maxCol);
            } while (!Map[spawnRow, spawnCol].Is(RCell.Walkable));

            _packManager.GeneratePack(spawnCol, spawnRow);

            return true;
        }

        public virtual void EnableEnemySpawning(IMobPackManager mobPackManager, int chance)
        {
            _spawningEnabled = true;
            _spawnChance = chance;
            _packManager = mobPackManager;
        }

        public void GetTopLeftCorner(ref int row, ref int col, Direction dir)
        {
            switch (dir)
            {
                case Direction.Center:
                    row -= OffsetY;
                    col -= OffsetX;
                    break;

                case Direction.North:
                    row -= OffsetY * 2;
                    col -= OffsetX;
                    break;

                case Direction.South:
                    col -= OffsetX;
                    break;

                case Direction.East:
                    row -= OffsetY;
                    break;

                case Direction.West:
                    row -= OffsetY;
                    col -= OffsetX * 2;
                    break;
            }
        }

        public abstract void GenerateImpl(int row, int col, Direction dir);

        private bool CheckAvailableSpace(int row, int col, Direction dir)
        {
            var topRow = row;
            var leftCol = col;

            GetTopLeftCorner(ref topRow, ref leftCol, dir);

            // We have to move one block away, or it's guaranteed to fail the check
            RHelper.MoveInDirection(ref topRow, ref leftCol, dir);

            for (var r = topRow; r < topRow + Height; ++r)
            {
                for (var c = leftCol; c < leftCol + Width; ++c)
                {
                    if (r < 0 || r >= Map.Rows || c < 0 || c >= Map.Columns)
                    {
                        return false;
                    }

                    if (!Map[r, c].Is(RCell.Diggable))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}