using System;
using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class RMap : Map<RCell>, IRMap
    {
        private readonly TCODMap _fovMap;

        public RMap()
        {
            _fovMap = new TCODMap(Columns, Rows);
        }

        public Rectangle HeatZone { get; private set; }

        public void RecalculateHeatZone()
        {
            int lowestX = Columns;
            int lowestY = Rows;
            int highestX = 0;
            int highestY = 0;

            // HeatZone may not be bigger than map + Boundary
            for (int row = 1; row < Rows - 2; ++row)
            {
                for (int col = 1; col < Columns - 2; ++col)
                {
                    if (!this[row, col].Is(RCell.Wall))
                    {
                        continue;
                    }

                    if (col < lowestX)
                    {
                        lowestX = col;
                    }

                    if (row < lowestY)
                    {
                        lowestY = row;
                    }

                    if (col > highestX)
                    {
                        highestX = col;
                    }

                    if (row > highestY)
                    {
                        highestY = row;
                    }
                }
            }

            // We want a border of one free space
            lowestX -= 1;
            lowestY -= 1;
            highestX += 2;
            highestY += 2;

            HeatZone = new Rectangle(lowestX, lowestY, highestX - lowestX, highestY - lowestY);
        }

        public void CreateFoVMap()
        {
            for (int row = 0; row < Rows; ++row)
            {
                for (int col = 0; col < Columns; ++col)
                {
                    RCell cell = this[row, col];
                    _fovMap.setProperties(col, row, cell.IsTransparent(), cell.IsWalkable());
                }
            }

            MapUpdated(_fovMap);
        }

        public ISubscribedFoVMap Subscribe()
        {
            var newMap = new SubscribedFoVMap(_fovMap);
            MapUpdated += newMap.OnUpdate;
            MapPartiallyUpdated += newMap.OnPartialUpdate;
            return newMap;
        }

        public void SetWalkable(int x, int y, bool walkable)
        {
            _fovMap.setProperties(x, y, _fovMap.isTransparent(x, y), walkable);
            MapPartiallyUpdated(x, y, walkable, _fovMap.isTransparent(x, y));
        }

        public void SetVisible(int x, int y, bool visible)
        {
            _fovMap.setProperties(x, y, visible, _fovMap.isWalkable(x, y));
            MapPartiallyUpdated(x, y, _fovMap.isWalkable(x, y), visible);
        }

        private event Action<TCODMap> MapUpdated = delegate { };
        private event Action<int, int, bool, bool> MapPartiallyUpdated = delegate { };
    }
}