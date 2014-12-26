using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class OverworldLogic : LogicState
    {
        public override void Run()
        {
            var camera = Model.OverworldModel.Camera;
            var player = Model.OverworldModel.Player;

            camera.CenterOn(player.Position.X, player.Position.Y);
            Model.CommitChanges();

            Input.Update();

            if (Input.Action(Actions.Confirm) && Model.Map[player.Position.Y, player.Position.X].Is(RCell.Portal))
            {
                Model.OverworldModel.GenerateNewMap(Model.Party.AveragePartyLvl);
                Model.Party.AddExperience(1000);
            }

            if (Input.Action(Actions.Back))
            {
                Model.OverworldModel.GenerateNewMap(Model.Party.AveragePartyLvl);
            }

            if (Input.Action(Actions.Cancel))
            {
                Master.Previous();
            }

            if (Input.Action(Actions.Right))
            {
                player.MoveRight();
            }

            if (Input.Action(Actions.Left))
            {
                player.MoveLeft();
            }

            if (Input.Action(Actions.Up))
            {
                player.MoveUp();
            }

            if (Input.Action(Actions.Down))
            {
                player.MoveDown();
            }

            if (Model.MobPackManager.ProcessTurns(player.Position.X, player.Position.Y))
            {
                Master.Next();
            }
        }
    }
}