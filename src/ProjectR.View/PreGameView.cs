using System.Drawing;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class PreGameView : ModelState
    {
        private readonly IRConsole _console;
        private readonly IMenuDrawer _menuDrawer;
        private readonly ICharDescriptionDrawer _charDescDrawer;
        private readonly IStatScreenDrawer _statScreenDrawer;
        private readonly ISpellDescriptionDrawer _normAttackDrawer;
        private readonly IAfflictionLister _afflictionLister;
        private readonly ISpellDescriptionDrawer _spell1Drawer;
        private readonly ISpellDescriptionDrawer _spell2Drawer;
        private readonly ISpellDescriptionDrawer _spell3Drawer;
        private readonly ISpellDescriptionDrawer _spell4Drawer;


        public PreGameView()
        {
            _console = new RConsole(39, 61);
            _menuDrawer = new MenuDrawer();
            _charDescDrawer = new CharDescriptionDrawer();
            _statScreenDrawer = new StatScreenDrawer();
        }

        public override void Run()
        {
            
        }
    }

    public class StatScreenDrawer : RConsole, IStatScreenDrawer
    {
        private static readonly Rectangle StatRectangle = new Rectangle(7, 9, 17, 9);
        private static readonly Rectangle StatStrengthRect = new Rectangle(29, 9, 17, 9);
        private static readonly Rectangle MasteryRect = new Rectangle(7, 22, 4, 9);
        private static readonly Rectangle MasteryStrengthRect = new Rectangle(13, 22, 4, 9);
        private static readonly Rectangle ResiRect = new Rectangle(26, 22, 2, 4);
        private static readonly Rectangle ResiStrengthRect = new Rectangle(29, 22, 4, 4);

        private Point _position;

        public StatScreenDrawer()
            : base(37, 32)
        {
        }

        public void DrawStats(ICharacter character, IRConsole targetConsole = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}