using System;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class MenuItem : IMenuItem
    {
        public bool IsDisabled { get; set; }
        public bool IsSelected { get; private set; }
        public string Label { get; set; }
        public Action CallBack { set; private get; }

        private Action _leftAction;
        private Action _rightAction;

        public MenuItem(string label)
        {
            Label = label;
            IsSelected = false;
            IsDisabled = false;
            CallBack = delegate { };
            _leftAction = delegate { };
            _rightAction = delegate { };
        }

        public MenuItem(string label, Action callBack)
            : this(label)
        {
            CallBack = callBack;
        }

        public void Activate()
        {
            IsSelected = true;
        }

        public void Deactivate()
        {
            IsSelected = false;
        }

        public void Run()
        {
            CallBack();
        }

        public void SetStateMachine(IStateMachine machine)
        {
        }
        
        public void SetLeftAction(Action leftAction)
        {
            _leftAction = leftAction;
        }

        public void SetRightAction(Action rightAction)
        {
            _rightAction = rightAction;
        }

        public void LeftAction()
        {
            _leftAction();
        }

        public void RightAction()
        {
            _rightAction();
        }
    }
}