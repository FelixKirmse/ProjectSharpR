using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public class TitleScreenLogic : LogicState
    {
        public override void Run()
        {
            Input.Update();
            if (Input.Action(Actions.Cancel))
            {
                ExitHelper.Exit();
            }
            else if (Input.Action(Actions.Confirm))
            {
                Master.Next();
            }

            Model.CommitChanges();
        }
    }
}