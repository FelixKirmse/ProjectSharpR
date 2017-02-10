using System.Linq;
using System.Text;
using libtcod;
using ProjectR.Interfaces.Extensions;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.View;

namespace ProjectR.View
{
    public class AfflictionLister : RConsole, IAfflictionLister
    {
        private int _posX;
        private int _posY;

        public AfflictionLister()
            : base(37, 29)
        {
        }

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public void ListAfflictions(ICharacter character, IModel model, IRConsole target = null)
        {
            var targetConsole = target ?? RootConsole;
            Clear();
            DrawBorder();
            var redControl = GetColorControlString(TCODColor.red);
            var stopControl = GetStopControl();
            PrintString(1, 1, string.Format("{0}Passives:{1}", redControl, stopControl));

            var passiveBuilder = new StringBuilder();
            var passives = model.CharacterFactory.GetPassives(character);
            int[] count = { 0 };
            foreach (var passive in passives.Where(passive => count[0] != 4))
            {
                passiveBuilder.Append(passive.Name).AppendNewLine().AppendNewLine();
                ++count[0];
            }

            PrintString(3, 3, passiveBuilder.ToString());
            PrintString(1, 11, string.Format("{0}Afflictions:{1}", redControl, stopControl));

            var afflictions = RHelper.ScriptHelper.GetAfflictions(character);
            count[0] = 13;
            var orangeControl = GetColorControlString(TCODColor.orange);
            var greenControl = GetColorControlString(TCODColor.green);

            foreach (var affliction in afflictions)
            {
                if (count[0] > 25)
                {
                    break;
                }

                PrintString(3, count[0],
                    string.Format("{0}{1}{2}", affliction.Type == AfflictionType.Debuff ? orangeControl : greenControl,
                        affliction.Name, stopControl));
                count[0] += 2;
            }

            targetConsole.Blit(this, Bounds, _posX, _posY);
        }
    }
}