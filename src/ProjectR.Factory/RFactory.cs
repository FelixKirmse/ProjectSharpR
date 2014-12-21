﻿using System;
using ProjectR.Interfaces.Model;
using ProjectR.Model;
using ProjectR.Model.States;

namespace ProjectR.Factory
{
    public class RFactory
    {
        public static IStateMachineSynchronizer CreateStateMachineSynchronizer()
        {
            return new StateMachineSynchronizer();
        }

        public static IRModel CreateModel()
        {
            return new RModel();
        }
    }
}
