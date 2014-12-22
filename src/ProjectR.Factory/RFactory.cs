using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;
using ProjectR.MapGen;
using ProjectR.Model;
using ProjectR.Model.States;
using ProjectR.Scripting;

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
            var model = new RModel();
            RHelper.ScriptHelper = new ScriptHelper { Model = model };
            return model;
        }

        public IMapGenerator CreateMapGenerator(IRMap map, IMobPackManager mobPackManager)
        {
            return new MapGenerator(map, mobPackManager);
        }

        public ISpell CreateScriptedSpell(IModel model, string file)
        {
            return new Spell(model, file);
        }

        public IAffliction CreateScriptedAffliction(IModel model, string file)
        {
            return new Affliction(model, file);
        }
    }
}
