using System.Drawing;

namespace ProjectR.Interfaces.Model
{
    public interface IOverworldCamera
    {
        int Speed { set; }

        void SetViewPortSize(int rows, int cols);
        void SetViewPortPosition(int row, int col);

        Rectangle ViewPort { get; }

        void MoveDown();
        void MoveUp();
        void MoveLeft();
        void MoveRight();

        void CenterOn(int x, int y);
    }
}