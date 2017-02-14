using System.Collections.Generic;
using System.Drawing;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class CommonBattleView : ModelState
    {
        private const int FrameOffset = 17;
        private static readonly Point EnemyMinionStart = new Point(24, 5);
        private static readonly Point EnemyStart = new Point(7, 16);
        private static readonly Point FrontRowStart = new Point(7, 30);
        private static readonly Point PartyMinionStart = new Point(24, 41);
        private readonly IList<ICharBattleFrame> _enemyFrames;
        private readonly IList<ICharBattleFrame> _enemyMinionFrames;
        private readonly IList<ICharBattleFrame> _frontRowFrames;
        private readonly BattleLogDrawer _logDrawer;
        private readonly IList<ICharBattleFrame> _partyMinionFrames;
        private IBattleModel _battleModel;
        private IList<ICharacter> _enemies;
        private IList<ICharacter> _enemyMinions;
        private IList<ICharacter> _frontRow;
        private IList<ICharacter> _partyMinions;

        public CommonBattleView()
        {
            _frontRowFrames = new List<ICharBattleFrame>();
            _partyMinionFrames = new List<ICharBattleFrame>();
            _enemyFrames = new List<ICharBattleFrame>();
            _enemyMinionFrames = new List<ICharBattleFrame>();

            _logDrawer = new BattleLogDrawer();
            _logDrawer.SetPosition(80, 35);

            for (var i = 0; i < 4; ++i)
            {
                _frontRowFrames.Add(CharBattleFrame.CreateFrameForPlayerChar());
                _frontRowFrames[i].SetPosition(FrontRowStart.X + FrameOffset * i, FrontRowStart.Y);

                _enemyFrames.Add(CharBattleFrame.CreateFrameForEnemyChar());
                _enemyFrames[i].SetPosition(EnemyStart.X + FrameOffset * i, EnemyStart.Y);

                if (i > 2)
                {
                    continue;
                }

                _partyMinionFrames.Add(CharBattleFrame.CreateFrameForPlayerChar());
                _partyMinionFrames[i].SetPosition(PartyMinionStart.X + FrameOffset * i, PartyMinionStart.Y);

                _enemyMinionFrames.Add(CharBattleFrame.CreateFrameForEnemyChar());
                _enemyMinionFrames[i].SetPosition(EnemyMinionStart.X + FrameOffset * i, EnemyMinionStart.Y);
            }
        }

        public override void Run()
        {
            DrawBorders();

            for (var i = 0; i < _frontRow.Count; ++i)
            {
                _frontRowFrames[i].AssignCharacter(_frontRow[i]);
                _frontRowFrames[i].Draw();
            }

            for (var i = 0; i < _partyMinions.Count; ++i)
            {
                _partyMinionFrames[i].AssignCharacter(_partyMinions[i]);
                _partyMinionFrames[i].Draw();
            }

            if (_battleModel.CurrentBattleState != BattleState.BattleWon)
            {
                for (var i = 0; i < _enemies.Count; ++i)
                {
                    _enemyFrames[i].AssignCharacter(_enemies[i], _battleModel.CurrentMobPack.GetStrength(_enemies[i]));
                    _enemyFrames[i].Draw();
                }

                for (var i = 0; i < _enemyMinions.Count; ++i)
                {
                    _enemyMinionFrames[i].AssignCharacter(_enemyMinions[i]);
                    _enemyMinionFrames[i].Draw();
                }
            }

            _logDrawer.Run();
        }

        private static void DrawBorders()
        {
            var enemyBorder = new RConsole(74, 24);
            var redControl = enemyBorder.GetColorControlString(TCODColor.red);
            var stopControl = enemyBorder.GetStopControl();

            enemyBorder.DrawBorder();
            enemyBorder.PrintString(1, 1, string.Format("{0}Enemy Party{1}", redControl, stopControl));

            var root = RConsole.RootConsole;
            root.Blit(enemyBorder, enemyBorder.Bounds, 3, 3);

            var playerBorder = new RConsole(74, 24);
            playerBorder.DrawBorder();
            playerBorder.PrintString(1, 22, string.Format("{0}Player Party{1}", redControl, stopControl));
            root.Blit(playerBorder, playerBorder.Bounds, 3, 28);
        }

        public override void Activate()
        {
            _battleModel = Model.BattleModel;
            _frontRow = _battleModel.FrontRow;
            _enemies = _battleModel.Enemies;
            _partyMinions = _battleModel.PlayerMinions;
            _enemyMinions = _battleModel.EnemyMinions;
            _logDrawer.Activate();
        }
    }
}