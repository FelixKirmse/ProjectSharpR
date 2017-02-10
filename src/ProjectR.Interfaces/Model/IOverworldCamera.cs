using System.Drawing;

namespace ProjectR.Interfaces.Model
{
    public interface IOverworldCamera
    {
        int Speed { set; }
        Rectangle ViewPort { get; }

        void SetViewPortSize(int colCount, int rowCount);
        void SetViewPortPosition(int col, int row);

        void MoveDown();
        void MoveUp();
        void MoveLeft();
        void MoveRight();

        void CenterOn(int x, int y);
    }
}