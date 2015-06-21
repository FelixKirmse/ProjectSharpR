using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class TargetSelectView : ModelState
    {
        private readonly IAfflictionLister _afflictionLister;
        private readonly ICharDescriptionDrawer _descDrawer;

        private readonly IRConsole _root;
        private readonly IStatScreenDrawer _statDrawer;

        public TargetSelectView()
        {
            _root = RConsole.RootConsole;
            _descDrawer = new CharDescriptionDrawer();
            _statDrawer = new StatScreenDrawer();
            _afflictionLister = new AfflictionLister();

            _descDrawer.SetPosition(80, 3);
            _statDrawer.SetPosition(80, 3);
            _afflictionLister.SetPosition(80, 35);
        }

        public override void Run()
        {
            _root.SetForegroundColour(TCODColor.white);
            _root.PrintString(22, 52, "Choose target for {0}", Model.BattleModel.TargetInfo.Spell.Name);

            var target = Model.BattleModel.TargetInfo.Target;
            if (Model.BattleModel.CharacterIsEnemy(target))
            {
                _descDrawer.DrawSummary(target);
            }
            else
            {
                _statDrawer.DrawStats(target);
            }

            _afflictionLister.ListAfflictions(target, Model);
        }
    }
}