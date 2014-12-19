using System.Drawing;

namespace ProjectR.Interfaces.Model
{
    public interface IOverworldPlayer
    {
        Point Position { get; set; }

        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void SetViewRadius(int radius);
        bool CanSee(int x, int y);
    }
}