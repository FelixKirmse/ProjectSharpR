using System.Drawing;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class OverworldPlayer : IOverworldPlayer
    {
        private readonly IRMap _map;
        private readonly IStatistics _statistics;
        private Point _position;
        private readonly ISubscribedFoVMap _fovMap;
        private int _viewRadius;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                RecaclulateFoV();
            }
        }

        public OverworldPlayer(IRMap map, IStatistics statistics)
        {
            _map = map;
            _statistics = statistics;
            _fovMap = _map.Subscribe();
            _viewRadius = 10;
        }

        public void MoveLeft()
        {
            Move(0, -1);
        }

        public void MoveRight()
        {
            Move(0, 1);
        }

        public void MoveUp()
        {
            Move(-1, 0);
        }

        public void MoveDown()
        {
            Move(1, 0);
        }

        public void SetViewRadius(int radius)
        {
            _viewRadius = radius;
        }

        public bool CanSee(int x, int y)
        {
            return _fovMap.IsVisible(x, y);
        }

        private void Move(int rows, int cols)
        {
            if (_fovMap.IsWalkable(_position.X + cols, _position.Y + rows))
            {
                _position.X += cols;
                _position.Y += rows;
                _statistics.AddToStatistic(Statistic.StepsTaken, 1);
            }

            var cell = _map[_position.Y, _position.X];
            if (cell.Is(RCell.Door) && cell.Is(RCell.Closed))
            {
                cell &= ~RCell.Closed;
                cell |= RCell.Open;
                _map[_position.Y, _position.X] = cell;
                _map.SetVisible(_position.X, _position.Y, true);
                _statistics.AddToStatistic(Statistic.DoorsOpened, 1);
            }

            RecaclulateFoV();
        }

        private void RecaclulateFoV()
        {
            _fovMap.CalculateFoV(_position.X, _position.Y, (int)(_map[_position.Y, _position.X].Is(RCell.Dark) ? _viewRadius / 2d : _viewRadius));
        }
    }
}