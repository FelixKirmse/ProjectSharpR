using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Factories
{
    public interface IRFactory
    {
        IStateMachineSynchronizer CreateStateMachineSynchronizer();
        IRModel CreateModel();
        IMapGenerator CreateMapGenerator(IRMap map, IMobPackManager mobPackManager);
        ISpell CreateScriptedSpell(IModel model, string file);
    }
}