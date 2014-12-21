﻿using System.Drawing;
using System.Web.UI.WebControls;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class OverworldModel : IOverworldModel
    {
        private readonly IModel _model;
        public IOverworldPlayer Player { get; private set; }
        public IMapGenerator MapGenerator { get; private set; }
        public IOverworldCamera Camera { get; private set; }

        public OverworldModel(IModel model)
        {
            _model = model;
            Player = new OverworldPlayer(_model.Map, model.Statistics);
            MapGenerator = new MapGenerator(_model.Map, model.MobPackManager);
            Camera = new OverworldCamera(_model.Map);
        }

        public void GenerateNewMap(int level)
        {
            var map = _model.Map;
            var heatZone = map.HeatZone;
            _model.Statistics.AddToStatistic(Statistic.MapsGenerated, 1);

            for (var row = heatZone.Top; row <= heatZone.Bottom; ++row)
            {
                for (var col = heatZone.Left; col <= heatZone.Right; ++col)
                {
                    if (map[row, col].Is(RCell.Grand | RCell.Artifact))
                    {
                        _model.Statistics.AddToStatistic(Statistic.GrandArtifactChestsMissed, 1);
                    }
                }
            }

            MapGenerator.GenerateMap(level);

            heatZone = map.HeatZone;
            for (var row = heatZone.Top; row <= heatZone.Bottom; ++row)
            {
                for (var col = heatZone.Left; col <= heatZone.Right; ++col)
                {
                    if (!map[row, col].Is(RCell.Spawn))
                    {
                        continue;
                    }

                    Player.Position = new Point(col, row);
                    Camera.CenterOn(col, row);
                    return;
                }
            }
        }
    }
}