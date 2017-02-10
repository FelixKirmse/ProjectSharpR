using System;
using System.Collections.Generic;
using libtcod;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public class Input<T> : IInput<T>
    {
        private readonly IDictionary<T, Pair<TCODKey, TCODKey>> _inputs;
        private TCODKey _currentInput;

        public Input()
        {
            _inputs = new Dictionary<T, Pair<TCODKey, TCODKey>>();
        }

        public void SetActionPrimary(T action, TCODKey key)
        {
            if (!_inputs.ContainsKey(action))
            {
                _inputs[action] = new Pair<TCODKey, TCODKey>();
            }

            _inputs[action].First = key;
        }

        public void SetActionSecondary(T action, TCODKey key)
        {
            if (!_inputs.ContainsKey(action))
            {
                _inputs[action] = new Pair<TCODKey, TCODKey>();
            }

            _inputs[action].Second = key;
        }

        public void SetAction(T action, Pair<TCODKey, TCODKey> keys)
        {
            _inputs[action] = keys;
        }

        public void BindActionPrimary(T action)
        {
            Update();
            SetActionPrimary(action, _currentInput);
        }

        public void BindActionSecondary(T action)
        {
            Update();
            SetActionSecondary(action, _currentInput);
        }

        public bool Action(T action, bool noChars = false)
        {
            return Check(_inputs[action].First, noChars) || Check(_inputs[action].Second, noChars);
        }

        public bool CheckAlt()
        {
            return _currentInput.LeftAlt || _currentInput.RightAlt;
        }

        public bool CheckCtrl()
        {
            return _currentInput.LeftControl || _currentInput.RightControl;
        }

        public bool CheckShift()
        {
            return _currentInput.Shift;
        }

        public void Update()
        {
            do
            {
                TCODConsole.flush();
                _currentInput = TCODConsole.checkForKeypress((int) TCODKeyStatus.KeyPressed);
                if (TCODConsole.isWindowClosed())
                {
                    Environment.Exit(0);
                }
            } while (_currentInput.KeyCode == TCODKeyCode.NoKey);
        }

        public char GetChar()
        {
            return _currentInput.KeyCode == TCODKeyCode.Char ? _currentInput.Character : '\0';
        }

        public virtual bool LoadConfig()
        {
            return false;
        }

        public virtual void SaveConfig()
        {
        }

        private bool Check(TCODKey key, bool noChars)
        {
            if (_currentInput.KeyCode != key.KeyCode)
            {
                return false;
            }

            if (key.KeyCode == TCODKeyCode.Char)
            {
                return _currentInput.Character == key.Character && !noChars;
            }

            return true;
        }
    }
}