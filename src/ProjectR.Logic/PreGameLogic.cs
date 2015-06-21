using System;
using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Logic
{
    public class PreGameLogic : LogicState, IMenu
    {
        public const string Name = "Name: ";
        public const string Race = "Race: ";
        public const string ArcheType = "Archetype: ";
        public const string SkillSet = "Skillset: ";
        public const string SignatureSpell = "Signature Spell: ";
        public const string NormalAttack = "Normal Attack: ";
        public const string FIR = "FIR: ";
        public const string WAT = "WAT: ";
        public const string ICE = "ICE: ";
        public const string ARC = "ARC: ";
        public const string WND = "WND: ";
        public const string HOL = "HOL: ";
        public const string DRK = "DRK: ";
        public const string GRN = "GRN: ";
        public const string LGT = "LGT: ";
        public const string CreateChar = "Create Character";
        private readonly IMenu _menu;

        #region Fields

        private IMenuItem _ARC;
        private int _ARCValue;
        private IMenuItem _DRK;
        private int _DRKValue;
        private IMenuItem _FIR;
        private int _FIRValue;
        private IMenuItem _GRN;
        private int _GRNValue;
        private IMenuItem _HOL;
        private int _HOLValue;
        private IMenuItem _ICE;
        private int _ICEValue;
        private IMenuItem _LGT;
        private int _LGTValue;
        private IMenuItem _WAT;
        private int _WATValue;
        private IMenuItem _WND;
        private int _WNDValue;
        private IMenuItem _archeType;
        private int _archeTypeIndex;
        private int _availableMasteryPoints;
        private IMenuController _controller;
        private IMenuItem _createChar;
        private IInputBuffer _inputBuffer;
        private IMenuItem _name;
        private IMenuItem _normalAttack;
        private int _normalAttackIndex;
        private IMenuItem _race;
        private int _raceIndex;
        private IMenuItem _signatureSpell;
        private int _signatureSpellIndex;
        private IMenuItem _skillSet;
        private int _skillSetIndex;
        private bool _switchViews;

        #endregion

        public PreGameLogic()
        {
            _menu = Factories.RFactory.CreateMenu();
        }

        public override void Run()
        {
            Input.Update();
            if (FirstStateActive() && (!Input.Action(Actions.Down, true) && !Input.Action(Actions.Up, true)))
            {
                HandleNameEntering();
                return;
            }

            _controller.ControlMenu(this, Input, Master.Previous);

            if (Input.Action(Actions.Confirm) && !FirstStateActive())
            {
                _switchViews = !_switchViews;
            }

            Model.PreGameModel.ShowStats = (GetCurrentStateNumber() <= 3 && !_switchViews) ||
                                           (GetCurrentStateNumber() > 3 && _switchViews);
            Model.CommitChanges();
        }

        public override void Activate()
        {
            Initialize();

            var races = Model.RaceFactory.Templates;
            var archeTypes = Model.ArcheTypeFactory.ArcheTypes;
            var skillSets = Model.SkillsetFactory.SkillSets;
            var signatureSpells = Model.SignatureSpellFactory.SignatureSpells;
            var normalAttacks = Model.NormalAttackFactory.NormalAttacks;

            _inputBuffer.Reset();
            _name.Label = Name;
            _race.Label = string.Format("{0}<{1}>", Race, races.First().Name);
            _archeType.Label = string.Format("{0}<{1}>", ArcheType, archeTypes.First().Name);
            _skillSet.Label = string.Format("{0}<{1}>", SkillSet, skillSets.First().Name);
            _signatureSpell.Label = string.Format("{0}<{1}>", SignatureSpell, signatureSpells.First().Name);
            _normalAttack.Label = string.Format("{0}<{1}>", NormalAttack, normalAttacks.First().Name);
            _FIR.Label = string.Format("{0}<50>", FIR);
            _WAT.Label = string.Format("{0}<50>", WAT);
            _ICE.Label = string.Format("{0}<50>", ICE);
            _ARC.Label = string.Format("{0}<50>", ARC);
            _WND.Label = string.Format("{0}<50>", WND);
            _HOL.Label = string.Format("{0}<50>", HOL);
            _DRK.Label = string.Format("{0}<50>", DRK);
            _GRN.Label = string.Format("{0}<50>", GRN);
            _LGT.Label = string.Format("{0}<50>", LGT);

            _raceIndex = 0;
            _archeTypeIndex = 0;
            _skillSetIndex = 0;
            _signatureSpellIndex = 0;
            _normalAttackIndex = 0;
            _FIRValue = 50;
            _WATValue = 50;
            _ICEValue = 50;
            _ARCValue = 50;
            _WNDValue = 50;
            _HOLValue = 50;
            _DRKValue = 50;
            _GRNValue = 50;
            _LGTValue = 50;
            _availableMasteryPoints = 550;

            _race.SetLeftAction(() => SwitchRace(-1));
            _race.SetRightAction(() => SwitchRace(1));

            SetLeftAndRightActions(_archeType, () => _archeTypeIndex, x => _archeTypeIndex = x, archeTypes, ArcheType,
                x => Model.PreGameModel.ArcheType = x);

            SetLeftAndRightActions(_skillSet, () => _skillSetIndex, x => _skillSetIndex = x, skillSets, SkillSet,
                x => Model.PreGameModel.Skillset = x);

            SetLeftAndRightActions(_signatureSpell, () => _signatureSpellIndex, x => _signatureSpellIndex = x,
                signatureSpells, SignatureSpell,
                x => Model.PreGameModel.SignatureSpell = x);

            SetLeftAndRightActions(_normalAttack, () => _normalAttackIndex, x => _normalAttackIndex = x, normalAttacks,
                NormalAttack,
                x => Model.PreGameModel.NormalAttack = x);

            Model.PreGameModel.RaceTemplate = races[_raceIndex];
            Model.PreGameModel.ArcheType = archeTypes[_archeTypeIndex];
            Model.PreGameModel.Skillset = skillSets[_skillSetIndex];
            Model.PreGameModel.SignatureSpell = signatureSpells[_signatureSpellIndex];
            Model.PreGameModel.NormalAttack = signatureSpells[_normalAttackIndex];

            SwitchList(() => _archeTypeIndex, x => _archeTypeIndex = x, 0, archeTypes, _archeType, ArcheType);
            SwitchList(() => _skillSetIndex, x => _skillSetIndex = x, 0, skillSets, _skillSet, SkillSet);
            SwitchList(() => _signatureSpellIndex, x => _signatureSpellIndex = x, 0, signatureSpells, _signatureSpell,
                SignatureSpell);
            SwitchList(() => _normalAttackIndex, x => _normalAttackIndex = x, 0, normalAttacks, _normalAttack,
                NormalAttack);

            SwitchRace(0);

            _FIR.SetLeftAction(() => ChangePoints(_FIR, ref _FIRValue, -1, FIR, EleMastery.FIR));
            _FIR.SetRightAction(() => ChangePoints(_FIR, ref _FIRValue, 1, FIR, EleMastery.FIR));
            _WAT.SetLeftAction(() => ChangePoints(_WAT, ref _WATValue, -1, WAT, EleMastery.WAT));
            _WAT.SetRightAction(() => ChangePoints(_WAT, ref _WATValue, 1, WAT, EleMastery.WAT));
            _ICE.SetLeftAction(() => ChangePoints(_ICE, ref _ICEValue, -1, ICE, EleMastery.ICE));
            _ICE.SetRightAction(() => ChangePoints(_ICE, ref _ICEValue, 1, ICE, EleMastery.ICE));
            _ARC.SetLeftAction(() => ChangePoints(_ARC, ref _ARCValue, -1, ARC, EleMastery.ARC));
            _ARC.SetRightAction(() => ChangePoints(_ARC, ref _ARCValue, 1, ARC, EleMastery.ARC));
            _WND.SetLeftAction(() => ChangePoints(_WND, ref _WNDValue, -1, WND, EleMastery.WND));
            _WND.SetRightAction(() => ChangePoints(_WND, ref _WNDValue, 1, WND, EleMastery.WND));
            _HOL.SetLeftAction(() => ChangePoints(_HOL, ref _HOLValue, -1, HOL, EleMastery.HOL));
            _HOL.SetRightAction(() => ChangePoints(_HOL, ref _HOLValue, 1, HOL, EleMastery.HOL));
            _DRK.SetLeftAction(() => ChangePoints(_DRK, ref _DRKValue, -1, DRK, EleMastery.DRK));
            _DRK.SetRightAction(() => ChangePoints(_DRK, ref _DRKValue, 1, DRK, EleMastery.DRK));
            _GRN.SetLeftAction(() => ChangePoints(_GRN, ref _GRNValue, -1, GRN, EleMastery.GRN));
            _GRN.SetRightAction(() => ChangePoints(_GRN, ref _GRNValue, 1, GRN, EleMastery.GRN));
            _LGT.SetLeftAction(() => ChangePoints(_LGT, ref _LGTValue, -1, LGT, EleMastery.LGT));
            _LGT.SetRightAction(() => ChangePoints(_LGT, ref _LGTValue, 1, LGT, EleMastery.LGT));

            _switchViews = false;

            ClearStates();
            AddState(_name);
            AddState(_race);
            AddState(_archeType);
            AddState(_normalAttack);
            AddState(_skillSet);
            AddState(_signatureSpell);
            AddState(_FIR);
            AddState(_WAT);
            AddState(_ICE);
            AddState(_ARC);
            AddState(_WND);
            AddState(_HOL);
            AddState(_DRK);
            AddState(_GRN);
            AddState(_LGT);
            AddState(_createChar);
            SetCurrentState(0);
            _name.Activate();

            for (var stat = EleMastery.FIR; stat <= EleMastery.LGT; ++stat)
            {
                Model.PreGameModel.SetMastery(stat, 50);
            }

            Model.MenuModel.ActiveMenu = this;
        }

        public override void InitializeImpl()
        {
            _inputBuffer = new InputBuffer();
            _controller = new MenuController();
            _name = Factories.RFactory.CreateMenuItem(Name);
            _race = Factories.RFactory.CreateMenuItem(Race);
            _archeType = Factories.RFactory.CreateMenuItem(ArcheType);
            _skillSet = Factories.RFactory.CreateMenuItem(SkillSet);
            _signatureSpell = Factories.RFactory.CreateMenuItem(SignatureSpell);
            _normalAttack = Factories.RFactory.CreateMenuItem(NormalAttack);
            _FIR = Factories.RFactory.CreateMenuItem(FIR);
            _WAT = Factories.RFactory.CreateMenuItem(WAT);
            _ICE = Factories.RFactory.CreateMenuItem(ICE);
            _ARC = Factories.RFactory.CreateMenuItem(ARC);
            _WND = Factories.RFactory.CreateMenuItem(WND);
            _HOL = Factories.RFactory.CreateMenuItem(HOL);
            _DRK = Factories.RFactory.CreateMenuItem(DRK);
            _GRN = Factories.RFactory.CreateMenuItem(GRN);
            _LGT = Factories.RFactory.CreateMenuItem(LGT);
            _createChar = Factories.RFactory.CreateMenuItem(CreateChar, () =>
            {
                Model.Party.AddCharacter(Model.PreGameModel.Character);
                Model.OverworldModel.GenerateNewMap(Model.PreGameModel.Character.CurrentLevel);
                Master.Next();
            });
            _controller.NoInputUpdate(true);
        }

        private void HandleNameEntering()
        {
            var input = Input.GetChar();

            if (Input.Action(Actions.Back, true))
            {
                _inputBuffer.RemoveChar();
                var name = _inputBuffer.GetString();
                UpdateName(name);
            }
            else if (Input.Action(Actions.Cancel, true))
            {
                Master.Previous();
            }
            else if (_inputBuffer.GetLength() < 16 && input != '\0')
            {
                _inputBuffer.AddChar(input);
                UpdateName(_inputBuffer.GetString());
            }

            Model.CommitChanges();
        }

        private void UpdateName(string name)
        {
            _name.Label = string.Format("{0}{1}", Name, name);
            Model.PlayerName = name;
            Model.PreGameModel.PlayerName = name;
        }

        private void ChangePoints(IMenuItem menuItem, ref int points, int change, string label, EleMastery stat)
        {
            var loops = 1;

            if (Input.CheckCtrl())
            {
                loops = 10;
            }

            if (Input.CheckAlt() || Input.CheckShift())
            {
                loops = 100;
            }

            for (var i = 0; i < loops; ++i)
            {
                if ((_availableMasteryPoints == 0 && change > 0) ||
                    (change < 0 && points == 50) ||
                    (points == 200 && change > 0) ||
                    (_availableMasteryPoints == 550 && change < 0))
                {
                    continue;
                }

                _availableMasteryPoints -= change;
                points += change;
            }

            menuItem.Label = string.Format("{0}<{1}>", label, points);
            Model.PreGameModel.AvailableMasteryPoints = _availableMasteryPoints;
            Model.PreGameModel.SetMastery(stat, points);
        }


        private void SetLeftAndRightActions<T>(IMenuItem menuItem, Func<int> getIndex, Action<int> setIndex,
                                               IList<T> list, string label, Action<T> setItem)
            where T : INameHolder
        {
            menuItem.SetLeftAction(() =>
            {
                SwitchList(getIndex, setIndex, -1, list, menuItem, label);
                setItem(list[getIndex()]);
            });

            menuItem.SetRightAction(() =>
            {
                SwitchList(getIndex, setIndex, 1, list, menuItem, label);
                setItem(list[getIndex()]);
            });
        }

        private void SwitchList<T>(Func<int> getIndex, Action<int> setIndex, int inkrement, IList<T> list,
                                   IMenuItem menuItem, string label)
            where T : INameHolder
        {
            var index = getIndex();
            index += inkrement;
            if (index < 0)
            {
                index = list.Count - 1;
            }

            if (index >= list.Count)
            {
                index = 0;
            }

            menuItem.Label = string.Format("{0}<{1}>", label, list[index].Name);

            if (menuItem == _signatureSpell)
            {
                menuItem.Label = string.Format("{0}\n\n<{1}>", label, list[index].Name);
            }

            setIndex(index);
        }

        private void SwitchRace(int inkrement)
        {
            _raceIndex += inkrement;
            var races = Model.RaceFactory.Templates;

            if (_raceIndex < 0)
            {
                _raceIndex = races.Count - 1;
            }

            if (_raceIndex >= races.Count)
            {
                _raceIndex = 0;
            }

            _race.Label = string.Format("{0}<{1}>", Race, races[_raceIndex].Name);

            Model.PreGameModel.RaceTemplate = races[_raceIndex];
            Model.PreGameModel.ShowStats = GetCurrentStateNumber() <= 3 && !_switchViews;
        }

        #region IMenu Delegation

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
    }
}