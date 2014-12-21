using System.Collections.Generic;
using System.Drawing;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class MobPack : IMobPack
    {
        public MobPackStrength Strength { get { return (MobPackStrength) (_totalStrength / _enemies.Count); } }

        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int XPReward { get; set; }
        public int SightRadius { get; set; }
        public int Size { get { return _enemies.Count; } }
        public int IntactCoreCount { get; private set; }
        public int UnstableCoreCount { get; private set; }
        public IList<ICharacter> Enemies { get { return _enemies; } }
        public IList<ICharacter> Minions { get { return _minions; } }

        private readonly List<ICharacter> _enemies;
        private readonly List<ICharacter> _minions;

        private readonly Dictionary<ICharacter, double> _convertBoni; 
        private readonly Dictionary<ICharacter, MobPackStrength> _strengths; 

        private readonly ISubscribedFoVMap _fovMap;
        private readonly IRMap _map;
        private Point _position;
        private double _totalStrength;

        public MobPack(IRMap map)
        {
            _map = map;
            _fovMap = _map.Subscribe();
            _enemies = new List<ICharacter>();
            _minions = new List<ICharacter>();
            _convertBoni = new Dictionary<ICharacter, double>();
            _strengths = new Dictionary<ICharacter, MobPackStrength>();
        }

        public void AddEnemy(ICharacter enemy, MobPackStrength strength = MobPackStrength.Stronger, double convertBonus = 1.2)
        {
            _enemies.Add(enemy);
            SetConvertBonus(enemy, convertBonus);
            SetStrength(enemy, strength);

            var coreCount = RHelper.RollPercentage(10) ? 2 : 1;
            if (RHelper.RollPercentage(20))
            {
                IntactCoreCount += coreCount;
            }
            else
            {
                UnstableCoreCount += coreCount;
            }
        }

        public void AddMinion(ICharacter minion)
        {
            _minions.Add(minion);
        }

        public void SetConvertBonus(ICharacter character, double bonus)
        {
            _convertBoni[character] = bonus;
        }

        public double GetConvertBonus(ICharacter character)
        {
            return _convertBoni[character];
        }

        public bool ProcessTurn(int playerX, int playerY)
        {
            _map.SetWalkable(Position.X, Position.Y, true);
            _map.SetVisible(Position.X, Position.Y, true);

            _fovMap.CalculateFoV(Position.X, Position.Y, SightRadius);

            if (_fovMap.IsVisible(playerX, playerY))
            {
                _fovMap.ComputePath(Position.X, Position.Y, playerX, playerY);
            }

            int wantX;
            int wantY;

            if (!_fovMap.PathAvailable())
            {
                do
                {
                    wantX = Position.X;
                    wantY = Position.Y;
                    RHelper.MoveInDirection(ref wantY, ref wantX, RHelper.GetRandomDirection());
                } while (!_fovMap.IsWalkable(wantX, wantY));
            }
            else
            {
                wantX = _position.X;
                wantY = _position.Y;
                _fovMap.WalkPath(ref wantX, ref wantY);
            }

            _position.X = wantX;
            _position.Y = wantY;

            var onPlayer = playerX == _position.X && playerY == _position.Y;

            _map.SetWalkable(_position.X, _position.Y, onPlayer);
            _map.SetVisible(_position.X, _position.Y, onPlayer);

            return onPlayer;
        }

        public void SetStrength(ICharacter enemy, MobPackStrength strength)
        {
            _strengths[enemy] = strength;
            _totalStrength += (int) strength;
        }

        public MobPackStrength GetStrength(ICharacter enemy)
        {
            return _strengths[enemy];
        }
    }
}