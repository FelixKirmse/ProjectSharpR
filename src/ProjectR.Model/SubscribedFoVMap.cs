using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SubscribedFoVMap : ISubscribedFoVMap
    {
        private readonly TCODMap _currentMap;
        private TCODPath _currentPath;
        private int _currentX;
        private int _currentY;
        private int _destX;
        private int _destY;

        public SubscribedFoVMap(TCODMap fovMap)
        {
            _currentPath = null;
            _currentMap = new TCODMap(1000, 1000);
            OnUpdate(fovMap);
        }

        public bool IsWalkable(int x, int y)
        {
            return _currentMap.isWalkable(x, y);
        }

        public bool IsVisible(int x, int y)
        {
            return _currentMap.isInFov(x, y);
        }

        public void CalculateFoV(int x, int y, int maxRadius)
        {
            _currentMap.computeFov(x, y, maxRadius, true, TCODFOVTypes.DiamondFov);
        }

        public void ComputePath(int origX, int origY, int destX, int destY)
        {
            if (_currentPath == null)
            {
                _currentPath = new TCODPath(_currentMap, 1.14f);
            }

            _currentPath.compute(origX, origY, destX, destY);
            _currentX = origX;
            _currentY = origY;
            _destX = destX;
            _destY = destY;
        }

        public void WalkPath(ref int posX, ref int posY)
        {
            _currentPath.walk(ref posX, ref posY, true);
            _currentX = posX;
            _currentY = posY;
        }

        public bool PathAvailable()
        {
            return _currentPath != null && !_currentPath.isEmpty();
        }

        public void OnUpdate(TCODMap currentMap)
        {
            _currentMap.copy(currentMap);

            if (_currentPath == null)
            {
                return;
            }

            _currentPath = new TCODPath(_currentMap, 1.14f);
            ComputePath(_currentX, _currentY, _destX, _destY);
        }

        public void OnPartialUpdate(int x, int y, bool walkable, bool visible)
        {
            _currentMap.setProperties(x, y, visible, walkable);

            if (_currentPath == null)
            {
                return;
            }

            _currentPath = new TCODPath(_currentMap, 1.14f);
            ComputePath(_currentX, _currentY, _destX, _destY);
        }
    }
}