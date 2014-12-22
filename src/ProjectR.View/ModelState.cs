﻿using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.View
{
    public abstract class ModelState : IState
    {
        public static IModel Model { get; set; }
        protected IStateMachine Master { get; private set; }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public abstract void Run();

        public void SetStateMachine(IStateMachine machine)
        {
            Master = machine;
        }
    }
}