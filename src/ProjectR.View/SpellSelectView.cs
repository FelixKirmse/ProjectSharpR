using System.Diagnostics;
using libtcod;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class SpellSelectView : InitializeableModelStateWithConsole
    {
        private readonly IMenuDrawer _drawer;
        private readonly ISpellDescriptionDrawer _spellDrawer;

        private const int CostX = 44;
        private const int DelayX = 51;
        private const int StartY = 2;
        private const int OffSetY = 2;
        private const string CostFormat = "{0}{1} MP{2}";
        private const string DelayFormat = "{0}{1}%{2}";

        public SpellSelectView()
            : base(55, 12)
        {
            _drawer = new MenuDrawer();
            _spellDrawer = new SpellDescriptionDrawer();
            _spellDrawer.SetPosition(80, 35);
        }

        public override void Run()
        {
            var menu = Model.MenuModel.SpellSelectMenu;

            Clear();
            PrintString(0, 0, "Spell select:");
            PrintString(39, 0, "Cost:  Delay:");

            _drawer.DrawMenu(menu, this, 3, 2, 1);

            var redControl = GetColorControlString(TCODColor.red);
            var whiteControl = GetColorControlString(TCODColor.white);
            var greyControl = GetColorControlString(TCODColor.grey);

            for (var i = 0; i < menu.GetStateCount(); ++i)
            {
                var item = menu.GetMenuItem(i);
                var spell = Model.SpellFactory.GetSpell(item.Label);

                PrintString(CostX, StartY + OffSetY * i, CostFormat, TCODAlignment.RightAlignment,
                    item.IsSelected ? redControl : item.IsDisabled ? greyControl : whiteControl,
                    (int) spell.GetMPCost(Model.BattleModel.CurrentAttacker), GetStopControl());

                PrintString(DelayX, StartY + OffSetY * i, DelayFormat, TCODAlignment.RightAlignment,
                    item.IsSelected ? redControl : item.IsDisabled ? greyControl : whiteControl,
                    (int) (100 - spell.Delay * 100d),
                    GetStopControl());
            }

            RConsole.RootConsole.Blit(this, Bounds, 22, 52);
            var currentItem = menu.CurrentState as IMenuItem;
            Debug.Assert(currentItem != null, "item != null");
            var currentSpell = Model.SpellFactory.GetSpell(currentItem.Label);
            _spellDrawer.DrawSpellDescription(currentSpell);
        }
    }
}