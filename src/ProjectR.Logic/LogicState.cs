using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public abstract class LogicState : InitializeableModelState
    {
        public static IRInput Input { get; set; }
    }
}