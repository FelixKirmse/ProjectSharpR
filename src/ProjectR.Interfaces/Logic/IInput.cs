using libtcod;
using ProjectR.Interfaces.Helper;

namespace ProjectR.Interfaces.Logic
{
    public interface IInput<in T>
    {
        void SetActionPrimary(T action, TCODKey key);
        void SetActionSecondary(T action, TCODKey key);
        void SetAction(T action, Pair<TCODKey, TCODKey> keys);

        void BindActionPrimary(T action);
        void BindActionSecondary(T action);

        bool Action(T action, bool noChars = false);
        bool CheckAlt();
        bool CheckCtrl();
        bool CheckShift();
        void Update();
        char GetChar();
        bool LoadConfig();
        void SaveConfig();
    }
}