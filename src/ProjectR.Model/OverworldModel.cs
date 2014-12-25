using System.Drawing;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class OverworldModel : IOverworldModel
    {
        private readonly IModel _model;

        public OverworldModel(IModel model)
        {
            _model = model;
            Player = new OverworldPlayer(_model.Map, model.Statistics);
            MapGenerator = Factories.RFactory.CreateMapGenerator(_model.Map, _model.MobPackManager);
            Camera = new OverworldCamera(_model.Map);
        }

        public IOverworldPlayer Player { get; private set; }
        public IMapGenerator MapGenerator { get; private set; }
        public IOverworldCamera Camera { get; private set; }

        public void GenerateNewMap(int level)
        {
            IRMap map = _model.Map;
            Rectangle heatZone = map.HeatZone;
            _model.Statistics.AddToStatistic(Statistic.MapsGenerated, 1);

            for (int row = heatZone.Top; row <= heatZone.Bottom; ++row)
            {
                for (int col = heatZone.Left; col <= heatZone.Right; ++col)
                {
                    if (map[row, col].Is(RCell.Grand | RCell.Artifact))
                    {
                        _model.Statistics.AddToStatistic(Statistic.GrandArtifactChestsMissed, 1);
                    }
                }
            }

            MapGenerator.GenerateMap(level);

            heatZone = map.HeatZone;
            for (int row = heatZone.Top; row <= heatZone.Bottom; ++row)
            {
                for (int col = heatZone.Left; col <= heatZone.Right; ++col)
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