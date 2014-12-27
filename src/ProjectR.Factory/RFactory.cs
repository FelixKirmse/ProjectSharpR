using System;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;
using ProjectR.Logic;
using ProjectR.MapGen;
using ProjectR.Model;
using ProjectR.Model.States;
using ProjectR.Scripting;
using ProjectR.View;

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
            RHelper.ScriptLoader = new ScriptLoader();
            ModelState.Model = model;
            return model;
        }

        public IMapGenerator CreateMapGenerator(IRMap map, IMobPackManager mobPackManager)
        {
            return new MapGenerator(map, mobPackManager);
        }

        public IAffliction CreateScriptedAffliction(IModel model, string file)
        {
            return new Affliction(model, file);
        }

        public IConsoleView CreateConsoleView()
        {
            return new ConsoleView();
        }

        public IRLogic CreateLogic()
        {
            return new RLogic();
        }

        public IMenu CreateMenu()
        {
            return new Menu();
        }

        public IMenuItem CreateMenuItem(string name)
        {
            return new MenuItem(name);
        }

        public IMenuItem CreateMenuItem(string name, Action callBack)
        {
            return new MenuItem(name, callBack);
        }
    }
}