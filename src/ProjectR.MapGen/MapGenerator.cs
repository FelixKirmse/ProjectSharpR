﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;
using ProjectR.MapGen.Generators;

namespace ProjectR.MapGen
{
    public class MapGenerator : IMapGenerator
    {
        private readonly int _cols;
        private readonly Direction[] _directions;
        private readonly RandomContainer<IGenerator> _generators;
        private readonly IRMap _map;
        private readonly IMobPackManager _mobPackManager;
        private readonly Dictionary<Direction, Direction> _oppositeDirections;
        private readonly int _rows;
        private int _featureTarget;

        public MapGenerator(IRMap map, IMobPackManager mobPackManager)
        {
            _map = map;
            _mobPackManager = mobPackManager;
            _rows = map.Rows;
            _cols = map.Columns;
            _directions = RHelper.GetDirections();
            _oppositeDirections = new Dictionary<Direction, Direction>
            {
                { Direction.North, Direction.South },
                { Direction.East, Direction.West },
                { Direction.South, Direction.North },
                { Direction.West, Direction.East },
                { Direction.Center, Direction.Center }
            };

            var roomGen = new RoomGenerator(5, 5, 10, 10, _map);
            var corridorGen = new HallwayGenerator(20, 20, 50, 50, _map);
            var drunkDrigger = new DrunkDigger(50, 50, 100, 100, _map);
            var treasureRoomGen = new TreasureRoom(5, 5, 13, 13, _map);

            _generators = new RandomContainer<IGenerator>
            {
                { roomGen, 60 },
                { corridorGen, 5 },
                { drunkDrigger, 180 },
                { treasureRoomGen, 2 }
            };

            roomGen.EnableEnemySpawning(_mobPackManager, 15);
            drunkDrigger.EnableEnemySpawning(_mobPackManager, 20);
        }

        public void GenerateMap(int level)
        {
            _mobPackManager.ClearPacks();
            _featureTarget = level * 2 + RHelper.Roll(5, 15);
            PrepareMap();
            GenerateFeatures();
            PlaceWarp();
            EnsureEnemies();
            PlacePortal();
            _map.RecalculateHeatZone();
            _map.CreateFoVMap();
        }

        public void PrepareMap()
        {
            for (var row = 0; row < _rows; ++row)
            {
                for (var col = 0; col < _cols; col++)
                {
                    if (row == 0 || col == 0 || row == _rows - 1 || col == _cols - 1)
                    {
                        _map[row, col] = RCell.Border;
                    }
                    else
                    {
                        _map[row, col] = RCell.Diggable;
                    }
                }
            }
            _generators.Get().Generate((int) (_rows / 2d), (int) (_cols / 2d), Direction.Center);
            _map.RecalculateHeatZone();
        }

        private bool ValidCell(int row, int col, ref Direction direction)
        {
            var cell = _map[row, col];

            if (!cell.Is(RCell.Wall))
            {
                return false;
            }

            _directions.ShuffleList();

            foreach (var dir in _directions)
            {
                direction = dir;
                var checkRow = row;
                var checkCol = col;
                RHelper.MoveInDirection(ref checkRow, ref checkCol, dir);

                var checkRowOpp = row;
                var checkColOpp = col;
                RHelper.MoveInDirection(ref checkRowOpp, ref checkColOpp, _oppositeDirections[dir]);

                if (_map[checkRow, checkCol].Is(RCell.Diggable) &&
                    _map[checkRowOpp, checkColOpp].Is(RCell.Walkable))
                {
                    return true;
                }
            }

            return false;
        }

        private void GenerateFeatures()
        {
            for (var i = 0; i < _featureTarget; i++)
            {
                int row;
                int col;
                var dir = Direction.Center;
                var sanity = 0;

                do
                {
                    FindSuitableSpot(out row, out col, (y, x) => !ValidCell(y, x, ref dir));
                    ++sanity;
                    if (sanity == 1000)
                    {
                        Debug.WriteLine("Sanity Check reached... Target: {0} Generated: {1}", _featureTarget, i);
                        return;
                    }
                } while (!_generators.Get().Generate(row, col, dir));
                _map.RecalculateHeatZone();
            }
        }

        private void PlaceWarp()
        {
            int row;
            int col;

            FindSuitableSpot(out row, out col, (y, x) => !_map[y, x].Is(RCell.Floor));

            _map[row, col] |= RCell.Spawn;
        }

        private void PlacePortal()
        {
            int row;
            int col;

            FindSuitableSpot(out row, out col, (y, x) => !_map[y, x].Is(RCell.Floor));

            _map[row, col] = RCell.Floor | RCell.Portal;
        }

        private void EnsureEnemies()
        {
            var packCount = _mobPackManager.PackCount;

            for (var i = packCount; i < 5; ++i)
            {
                int row;
                int col;

                FindSuitableSpot(out row, out col, (y, x) => !_map[y, x].Is(RCell.Floor));

                _mobPackManager.GeneratePack(col, row);
            }
        }

        private void FindSuitableSpot(out int row, out int col, Func<int, int, bool> predicate)
        {
            var heatZone = _map.HeatZone;

            do
            {
                row = RHelper.Roll(heatZone.Top, heatZone.Bottom);
                col = RHelper.Roll(heatZone.Left, heatZone.Right);
            } while (predicate(row, col));
        }
    }
}