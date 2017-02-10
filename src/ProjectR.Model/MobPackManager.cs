using System;
using System.Collections.Generic;
using System.Drawing;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class MobPackManager : IMobPackManager
    {
        private readonly IModel _model;
        private readonly List<IMobPack> _packs;

        public MobPackManager(IModel model)
        {
            _model = model;
            _packs = new List<IMobPack>();
        }

        public IList<IMobPack> MobPacks { get { return _packs; } }
        public int PackCount { get { return _packs.Count; } }

        public void ClearPacks()
        {
            _packs.Clear();
        }

        public void GeneratePack(int x, int y)
        {
            var pack = new MobPack(_model.Map) { Position = new Point(x, y) };
            var enemyCount = _model.Party.FrontRow.Count - RHelper.Roll(0, 1);

            if (enemyCount == 0)
            {
                ++enemyCount;
            }

            var xpReward = 0;

            // 25% Chance to get a group of enemies with the same race
            var raceGroup = RHelper.RollPercentage(25) ? _model.RaceFactory.GetRandomTemplate() : null;

            for (var i = 0; i < enemyCount; ++i)
            {
                var strengthRoll = RHelper.Roll(0, 99);
                var strength = strengthRoll < 60
                    ? MobPackStrength.Equal
                    : strengthRoll < 90
                        ? MobPackStrength.Stronger
                        : strengthRoll < 98
                            ? MobPackStrength.Challenging
                            : MobPackStrength.Elite;

                xpReward += GenerateEnemy(pack, raceGroup, strength);
            }

            pack.XPReward = xpReward;

            switch (pack.Strength)
            {
                case MobPackStrength.Equal:
                    pack.SightRadius = 25;
                    break;

                case MobPackStrength.Stronger:
                    pack.SightRadius = 20;
                    break;

                case MobPackStrength.Challenging:
                    pack.SightRadius = 10;
                    break;

                case MobPackStrength.Elite:
                    pack.SightRadius = 5;
                    break;
            }

            _packs.Add(pack);
        }

        public void GenerateBoss(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void GenerateProjectR(int x, int y)
        {
            // If you read this while actually implementing him: Congrats that youve come so far!!!!
            // Probably hopefully not much more to do until release! You da boss!
            throw new NotImplementedException();
        }

        public bool ProcessTurns(int playerX, int playerY)
        {
            var result = false;
            for (var i = 0; i < _packs.Count; ++i)
            {
                var pack = _packs[i];

                if (pack.ProcessTurn(playerX, playerY))
                {
                    var cell = _model.Map[playerX, playerY];
                    var statBonus = cell.GetStatBonus();
                    _model.BattleModel.StartBattle(pack, statBonus, cell.Is(RCell.DoubleCombatBonus));
                    _packs.RemoveAt(i);
                    --i;
                    result = true;
                }
            }

            return result;
        }

        private int GenerateEnemy(IMobPack pack, IRaceTemplate race, MobPackStrength strength)
        {
            var charFac = _model.CharacterFactory;

            var newEnemy = charFac.CreateRandomCharacter(1, race);

            switch (strength)
            {
                case MobPackStrength.Stronger:
                    pack.AddEnemy(newEnemy, strength, 1.2d);
                    return 40;

                case MobPackStrength.Challenging:
                    pack.AddEnemy(newEnemy, strength, 1.5d);
                    return 60;

                case MobPackStrength.Elite:
                    pack.AddEnemy(newEnemy, strength, 2d);
                    return 100;

                default:
                    pack.AddEnemy(newEnemy, strength, 1.1d);
                    return 25;
            }
        }
    }
}