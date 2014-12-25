using System;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Logic
{
    public interface IMenuController
    {
        void ControlMenu(IMenu menu, IRInput input, Action cancelCallback);
        void NoInputUpdate(bool update);
    }
}