using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class ActionSelect : LogicState, IMenu
    {
        private readonly IMenu _menu;
        private IMenuItem _attack;
        private IBattleModel _battleModel;
        private IMenuController _controller;
        private IMenuItem _convince;
        private IMenuItem _defend;
        private IMenuItem _formation;
        private IMenuItem _spell;
        private IMenuItem _switch;

        public ActionSelect()
        {
            _menu = Factories.RFactory.CreateMenu();
        }

        public override void Activate()
        {
            Initialize();

            _attack = Factories.RFactory.CreateMenuItem(_battleModel.CurrentAttacker.Spells[0].Name, SetAttack);
            _defend = Factories.RFactory.CreateMenuItem(_battleModel.CurrentAttacker.Spells[1].Name, SetDefend);

            ClearStates();
            AddState(_attack);
            AddState(_defend);
            AddState(_spell);
            AddState(_switch);
            AddState(_formation);
            AddState(_convince);
            SetCurrentState(0);
            _attack.Activate();
            _convince.IsDisabled = Model.BattleModel.Enemies.Count != 1;
            _spell.IsDisabled = Model.BattleModel.CurrentAttacker.IsSilenced;
            _formation.IsDisabled = Model.BattleModel.FrontRow.Count == 1;
            _switch.IsDisabled = Model.Party.BackSeat.Count == 0;
            Model.CommitChanges();
        }

        public override void Run()
        {
            _attack.Label = _battleModel.CurrentAttacker.Spells[0].Name;
            _defend.Label = _battleModel.CurrentAttacker.Spells[1].Name;
            _controller.ControlMenu(this, Input, () => { });
            Model.CommitChanges();
        }

        #region IMenu Implementation

        public IState CurrentState { get { return _menu.CurrentState; } }

        public void Next()
        {
            _menu.Next();
        }

        public void Previous()
        {
            _menu.Previous();
        }

        public void AddState(IState state)
        {
            _menu.AddState(state);
        }

        public void RunCurrentState()
        {
            _menu.RunCurrentState();
        }

        public IState GetState(int index)
        {
            return _menu.GetState(index);
        }

        public void SetCurrentState(int index)
        {
            _menu.SetCurrentState(index);
        }

        public void ClearStates()
        {
            _menu.ClearStates();
        }

        public int GetStateCount()
        {
            return _menu.GetStateCount();
        }

        public bool FirstStateActive()
        {
            return _menu.FirstStateActive();
        }

        public int GetCurrentStateNumber()
        {
            return _menu.GetCurrentStateNumber();
        }

        public IMenuItem GetMenuItem(int index)
        {
            return _menu.GetMenuItem(index);
        }

        public void LeftAction()
        {
            _menu.LeftAction();
        }

        public void RightAction()
        {
            _menu.RightAction();
        }

        public void Sync(int value)
        {
            _menu.Sync(value);
        }

        public void SetSynchronizer(ISynchronizer<int> syncer)
        {
            _menu.SetSynchronizer(syncer);
        }

        #endregion

        public override void InitializeImpl()
        {
            _battleModel = Model.BattleModel;
            _spell = Factories.RFactory.CreateMenuItem("Spell",
                () => Master.SetCurrentState((int) BattleMenuState.SelectSpell));
            _switch = Factories.RFactory.CreateMenuItem("Switch",
                () => Master.SetCurrentState((int) BattleMenuState.Switch));
            _convince = Factories.RFactory.CreateMenuItem("Convert",
                () => Master.SetCurrentState((int) BattleMenuState.Convince));
            _formation = Factories.RFactory.CreateMenuItem("Set Formation",
                () => Master.SetCurrentState((int) BattleMenuState.SetFormation));
            _controller = new MenuController();
            Model.MenuModel.BattleMenu = this;
        }

        private void SetDefend()
        {
            var targetInfo = _battleModel.TargetInfo;
            targetInfo.Spell = _battleModel.CurrentAttacker.Spells[1];
            _battleModel.TargetInfo = targetInfo;
            Master.SetCurrentState((int) BattleMenuState.SelectTarget);
        }

        private void SetAttack()
        {
            var targetInfo = _battleModel.TargetInfo;
            targetInfo.Spell = _battleModel.CurrentAttacker.Spells[0];
            _battleModel.TargetInfo = targetInfo;
            Master.SetCurrentState((int) BattleMenuState.SelectTarget);
        }
    }
}