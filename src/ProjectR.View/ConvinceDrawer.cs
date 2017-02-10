using System.Drawing;
using libtcod;

namespace ProjectR.View
{
    public class ConvinceDrawer : InitializeableModelStateWithConsole
    {
        private const string FormatString = "Your attempt to convert\n\n{0}\n\n{1}{2}{3}\n\n{0}{4}";
        private const string Success = "was successful!";
        private const string Failed = "failed...";
        private const string Joined = "joined the party";
        private const string NoJoin = "did not join the party";

        public ConvinceDrawer()
            : base(33, 15)
        {
        }

        public override void Run()
        {
            Clear();
            DrawBorder();

            var target = Model.BattleModel.TargetInfo.Target;
            var targetName = target.Name;
            var success = target.IsMarked;

            var controlCode = GetColorControlString(success ? TCODColor.green : TCODColor.red);
            PrintString(new Rectangle(16, 2, 29, 11), FormatString, TCODAlignment.CenterAlignment, targetName,
                controlCode, success ? Success : Failed, GetStopControl(), success ? Joined : NoJoin);
            RConsole.RootConsole.Blit(this, Bounds, 24, 20);
        }
    }
}