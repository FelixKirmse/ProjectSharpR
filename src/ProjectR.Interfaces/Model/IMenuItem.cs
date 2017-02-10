using System;

namespace ProjectR.Interfaces.Model
{
    public interface IMenuItem : IState
    {
        bool IsDisabled { get; set; }
        bool IsSelected { get; }
        string Label { get; set; }
        Action CallBack { set; }

        void SetLeftAction(Action leftAction);
        void SetRightAction(Action rightAction);

        void LeftAction();
        void RightAction();
    }
}