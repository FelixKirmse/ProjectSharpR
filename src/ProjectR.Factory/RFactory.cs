using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;
using ProjectR.MapGen;
using ProjectR.Model;
using ProjectR.Model.States;

namespace ProjectR.Factory
{
    public class RFactory : IRFactory
    {
        public IStateMachineSynchronizer CreateStateMachineSynchronizer()
        {
            return new StateMachineSynchronizer();
        }

        public IRModel CreateModel()
        {
            return new RModel();
        }

        public IMapGenerator CreateMapGenerator(IRMap map, IMobPackManager mobPackManager)
        {
            return new MapGenerator(map, mobPackManager);
        }
    }
}
