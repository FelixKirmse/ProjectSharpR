using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public class RLogic : StateMachine, IRLogic
    {
        public RLogic()
        {
            LogicState.Input = new RInput();
        }

        public void InitializeStates()
        {
            AddState(new TitleScreenLogic());
            AddState(new MainMenuLogic());
            AddState(new PreGameLogic());
            AddState(new OverworldLogic());
            AddState(new BattleLogic());
        }
    }
}