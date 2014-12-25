using System.Drawing;

namespace ProjectR.Interfaces.Model
{
    public interface IRMap : IMap<RCell>
    {
        Rectangle HeatZone { get; }

        void RecalculateHeatZone();
        void CreateFoVMap();
        ISubscribedFoVMap Subscribe();

        void SetWalkable(int x, int y, bool walkable);
        void SetVisible(int x, int y, bool visible);
    }
}