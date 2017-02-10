using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class OverworldView : ModelState
    {
        private readonly IMapDrawer _mapDrawer;

        public OverworldView()
        {
            _mapDrawer = new MapDrawer();
            _mapDrawer.SetPosition(0, 0);
        }

        public override void Activate()
        {
            Model.OverworldModel.Camera.SetViewPortSize(RConsole.RootConsole.Width, RConsole.RootConsole.Height);
            Model.OverworldModel.Camera.SetViewPortPosition(Model.Map.HeatZone.X, Model.Map.HeatZone.Y);
        }

        public override void Run()
        {
            _mapDrawer.DrawMap(Model.Map,
                Model.OverworldModel.Camera,
                Model.OverworldModel.Player,
                Model.MobPackManager,
                Model.Statistics);
        }
    }
}