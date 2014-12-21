using System.Diagnostics;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Menu : StateMachine, IMenu
    {
        private IMenuItem CurrentMenuItem { get { return CurrentState as IMenuItem; } }

        public void Activate()
        {
            SetCurrentState(0);
        }

        public void Deactivate()
        {
        }

        public void Run()
        {
            if (!CurrentMenuItem.IsDisabled)
            {
                RunCurrentState();
            }
        }

        public void SetStateMachine(IStateMachine machine)
        {
        }

        public void LeftAction()
        {
            CurrentMenuItem.LeftAction();
        }

        public void RightAction()
        {
            CurrentMenuItem.RightAction();
        }

        public override void Next()
        {
            var stateCount = GetStateCount();
            for (var i = 0; i < stateCount; ++i)
            {
                var menuItem = GetState(i) as IMenuItem;
                Debug.Assert(menuItem != null, "menuItem != null");
                if (!menuItem.IsSelected)
                {
                    continue;
                }

                menuItem.Deactivate();
                SetCurrentState(i == stateCount - 1 ? 0 : i + 1);
                var nextMenuItem = CurrentMenuItem;
                nextMenuItem.Activate();
                if (nextMenuItem.IsDisabled)
                {
                    Next();
                }
                break;
            }
        }

        public override void Previous()
        {
            var stateCount = GetStateCount();
            for (var i = 0; i < stateCount; ++i)
            {
                var menuItem = GetState(i) as IMenuItem;
                Debug.Assert(menuItem != null, "menuItem != null");
                if (!menuItem.IsSelected)
                {
                    continue;
                }

                menuItem.Deactivate();
                SetCurrentState(i == 0 ? stateCount - 1 : i - 1);
                var lastMenuItem = CurrentMenuItem;
                lastMenuItem.Activate();
                if (lastMenuItem.IsDisabled)
                {
                    Previous();
                }
                break;
            }
        }
    }
}