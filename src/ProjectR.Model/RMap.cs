using System;
using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class RMap : Map<RCell>, IRMap
    {
        public Rectangle HeatZone { get; private set; }

        private TCODMap _fovMap;
        private event Action<TCODMap> MapUpdated = delegate { };
        private event Action<int, int, bool, bool> MapPartiallyUpdated = delegate { };

        public RMap()
        {
            _fovMap = new TCODMap(Columns, Rows);
        }

        public void RecalculateHeatZone()
        {
            var lowestX = Columns;
            var lowestY = Rows;
            var highestX = 0;
            var highestY = 0;

            // HeatZone may not be bigger than map + Boundary
            for (var row = 1; row < Rows - 2; ++row)
            {
                for (var col = 1; col < Columns - 2; ++col)
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
            for (var row = 0; row < Rows; ++row)
            {
                for (var col = 0; col < Columns; ++col)
                {
                    var cell = this[row, col];
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
    }
}