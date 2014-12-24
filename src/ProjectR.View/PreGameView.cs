using System;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Threading;
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
            _normAttackDrawer = new SpellDescriptionDrawer();
            _afflictionLister = new AfflictionLister();
        }

        public override void Run()
        {
            
        }
    }
}