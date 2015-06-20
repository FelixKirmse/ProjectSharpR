using System;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.MapGen;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.Interfaces.Factories
{
    public interface IRFactory
    {
        IStateMachineSynchronizer CreateStateMachineSynchronizer();
        IRModel CreateModel();
        IMapGenerator CreateMapGenerator(IRMap map, IMobPackManager mobPackManager);
        IConsoleView CreateConsoleView();
        IRLogic CreateLogic();
        IMenu CreateMenu();
        IMenuItem CreateMenuItem(string name);
        IMenuItem CreateMenuItem(string name, Action callBack);
    }
}