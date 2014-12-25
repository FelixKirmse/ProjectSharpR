using System;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class MenuController : IMenuController
    {
        private bool _noUpdate;

        public void ControlMenu(IMenu menu, IRInput input, Action cancelCallback)
        {
            if (!_noUpdate)
            {
                input.Update();
            }

            if (input.Action(Actions.Up))
            {
                menu.Previous();
            }
            else if (input.Action(Actions.Down))
            {
                menu.Next();
            }
            else if (input.Action(Actions.Cancel))
            {
                cancelCallback();
            }
            else if (input.Action(Actions.Confirm))
            {
                menu.Run();
            }
            else if (input.Action(Actions.Right))
            {
                menu.RightAction();
            }
            else if (input.Action(Actions.Left))
            {
                menu.LeftAction();
            }
        }

        public void NoInputUpdate(bool update)
        {
            _noUpdate = update;
        }
    }
}