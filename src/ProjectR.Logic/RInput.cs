using libtcod;
using ProjectR.Interfaces.Logic;

namespace ProjectR.Logic
{
    public sealed class RInput : Input<Actions>, IRInput
    {
        public RInput()
        {
            if (!LoadConfig())
            {
                SetDefaults();
            }
        }

        private void SetDefaults()
        {
            Set(Actions.None, GetKey());
            Set(Actions.Up, GetKey(TCODKeyCode.Up), GetKey(TCODKeyCode.Char, 'w'));
            Set(Actions.Down, GetKey(TCODKeyCode.Down), GetKey(TCODKeyCode.Char, 's'));
            Set(Actions.Left, GetKey(TCODKeyCode.Left), GetKey(TCODKeyCode.Char, 'a'));
            Set(Actions.Right, GetKey(TCODKeyCode.Right), GetKey(TCODKeyCode.Char, 'd'));
            Set(Actions.Confirm, GetKey(TCODKeyCode.Enter), GetKey(TCODKeyCode.Char, 'e'));
            Set(Actions.Cancel, GetKey(TCODKeyCode.Escape), GetKey(TCODKeyCode.Char, 'q'));
            Set(Actions.Inventory, GetKey(TCODKeyCode.Char, 'i'));
            Set(Actions.Party, GetKey(TCODKeyCode.Char, 'p'));
            Set(Actions.Back, GetKey(TCODKeyCode.Backspace));
        }

        private static TCODKey GetKey(TCODKeyCode code = TCODKeyCode.NoKey, char character = '\0')
        {
            return new TCODKey
            {
                KeyCode = code,
                Character = character
            };
        }

        private void Set(Actions action, TCODKey primary)
        {
            Set(action, primary, primary);
        }

        private void Set(Actions action, TCODKey primary, TCODKey secondary)
        {
            SetActionPrimary(action, primary);
            SetActionSecondary(action, secondary);
        }
    }
}