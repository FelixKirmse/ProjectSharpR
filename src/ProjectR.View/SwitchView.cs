using System.Collections.Generic;
using System.Linq;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class SwitchView : InitializeableModelState
    {
        private IRConsole _root;
        private readonly IRConsole _clearConsole;
        private readonly IRConsole _borderConsole;

        private const int StartX = 7;
        private const int StartY = 5;
        private const int RowOffset = 11;
        private const int ColOffset = 17;
        private const int FrontRowSize = 4;

        private readonly IList<ICharBattleFrame> _frames;
        private readonly IStatScreenDrawer _drawer;
        private readonly ISpellLister _lister;

        public SwitchView()
        {
            _frames = new List<ICharBattleFrame>();
            _drawer = new StatScreenDrawer();
            _lister = new SpellLister();
            _clearConsole = new RConsole(72, 22);
            _borderConsole = new RConsole(16, 10);

            _drawer.SetPosition(80, 3);
            _lister.SetPosition(80, 35);
        }

        public override void InitializeImpl()
        {
            _root = RConsole.RootConsole;
            for (var i = 0; i < 8; ++i)
            {
                var x = StartX + ColOffset * (i % 4);
                var y = StartY + (i < 4 ? 0 : RowOffset);

                _frames.Add(CharBattleFrame.CreateFrameForPlayerChar());
                _frames[i].SetPosition(x, y);
            }
        }

        public override void Run()
        {
            Initialize();

            _root.Blit(_clearConsole, _clearConsole.Bounds, 4, 4);
            var redControl = _root.GetColorControlString(TCODColor.red);
            _root.PrintString(4, 4, "{0}Reserve Party{1}", redControl, _root.GetStopControl());

            var deadCount = FrontRowSize - Model.Party.FrontRow.Count;
            var selectedFrontRow = Model.MenuModel.SelectedSwitchIndex;

            for (var i = FrontRowSize - deadCount; i < FrontRowSize; ++i)
            {
                _borderConsole.SetForegroundColour(selectedFrontRow == i ? TCODColor.red : TCODColor.white);
                _borderConsole.DrawBorder();
                _root.Blit(_borderConsole, _borderConsole.Bounds, StartX + ColOffset * i, 30);
            }

            var backSeat = Model.Party.BackSeat;
            for (var i = 0; i < backSeat.Count; ++i)
            {
                _frames[i].AssignCharacter(backSeat[i]);
                _frames[i].Draw();
            }

            ICharacter selectedCharacter = null;
            var backRowSelected = false;

            foreach (var character in backSeat.Where(character => character.IsMarked))
            {
                backRowSelected = true;
                selectedCharacter = character;
                break;
            }

            if (!backRowSelected)
            {
                foreach (var character in Model.Party.FrontRow.Where(character => character.IsMarked))
                {
                    selectedCharacter = character;
                    break;
                }
            }

            if (selectedCharacter == null)
            {
                return;
            }

            _drawer.DrawStats(selectedCharacter);
            _lister.Draw(selectedCharacter);
        }
    }
}