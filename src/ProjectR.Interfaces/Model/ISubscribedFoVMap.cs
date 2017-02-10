namespace ProjectR.Interfaces.Model
{
    public interface ISubscribedFoVMap
    {
        bool IsWalkable(int x, int y);
        bool IsVisible(int x, int y);
        void CalculateFoV(int x, int y, int maxRadius);
        void ComputePath(int origX, int origY, int destX, int destY);
        void WalkPath(ref int posX, ref int posY);
        bool PathAvailable();
    }
}