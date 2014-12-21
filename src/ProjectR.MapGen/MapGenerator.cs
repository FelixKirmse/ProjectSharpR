using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;

namespace ProjectR.MapGen
{
    public class MapGenerator : IMapGenerator
    {
        public MapGenerator(IRMap map, IMobPackManager mobPackManager)
        {
            
        }

        public void GenerateMap(int level)
        {
            throw new System.NotImplementedException();
        }
    }
}