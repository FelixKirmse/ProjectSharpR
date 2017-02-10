using ProjectR.Interfaces.MapGen;

namespace ProjectR.Interfaces.Model
{
    public interface IOverworldModel
    {
        IOverworldPlayer Player { get; }
        IMapGenerator MapGenerator { get; }
        IOverworldCamera Camera { get; }

        void GenerateNewMap(int level);
    }
}