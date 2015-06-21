using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public class GameOverLogic : LogicState
    {
        private bool _gameOver;

        public bool IsGameOver
        {
            get
            {
                var result = _gameOver;
                if (result)
                {
                    _gameOver = false;
                }
                return result;
            }
        }

        public override void Run()
        {
            Model.CommitChanges();
            do
            {
                Input.Update();
            } while (!Input.Action(Actions.Confirm));
            _gameOver = true;
        }
    }
}