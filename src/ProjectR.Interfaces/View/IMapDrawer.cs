using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface IMapDrawer
    {
        void SetPosition(int x, int y);

        void DrawMap(IRMap map, IOverworldCamera camera, IOverworldPlayer player, IMobPackManager mobPackManager,
                     IStatistics statistics, IRConsole target = null);
    }
}