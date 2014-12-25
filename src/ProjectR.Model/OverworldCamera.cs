using System.Drawing;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class OverworldCamera : IOverworldCamera
    {
        private readonly IRMap _map;
        private Rectangle _viewPort;

        public OverworldCamera(IRMap map)
        {
            _map = map;
            Speed = 1;
        }

        public int Speed { set; private get; }

        public Rectangle ViewPort { get { return _viewPort; } }

        public void SetViewPortSize(int colCount, int rowCount)
        {
            _viewPort.Width = colCount;
            _viewPort.Height = rowCount;
        }

        public void SetViewPortPosition(int col, int row)
        {
            _viewPort.X = col;
            _viewPort.Y = row;
        }

        public void MoveDown()
        {
            Move(1, 0);
        }

        public void MoveUp()
        {
            Move(-1, 0);
        }

        public void MoveLeft()
        {
            Move(0, -1);
        }

        public void MoveRight()
        {
            Move(0, 1);
        }

        public void CenterOn(int x, int y)
        {
            _viewPort.X = (int) (x - _viewPort.Width / 2d);
            _viewPort.Y = (int) (y - _viewPort.Height / 2d);

            Move(0, 0);
        }

        private void Move(int rows, int cols)
        {
            Rectangle heatZone = _map.HeatZone;

            for (int i = 0; i < Speed; ++i)
            {
                _viewPort.X += cols;
                _viewPort.Y += rows;
            }

            if (_viewPort.Bottom > heatZone.Bottom)
            {
                _viewPort.Y = heatZone.Bottom - _viewPort.Height;
            }

            if (_viewPort.Right > heatZone.Right)
            {
                _viewPort.X = heatZone.Right - _viewPort.Width;
            }

            if (_viewPort.X < heatZone.X)
            {
                _viewPort.X = heatZone.X;
            }

            if (_viewPort.Y < heatZone.Y)
            {
                _viewPort.Y = heatZone.Y;
            }
        }
    }
}