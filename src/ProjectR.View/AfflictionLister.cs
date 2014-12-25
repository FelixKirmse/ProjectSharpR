using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
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
            IRConsole targetConsole = target ?? RootConsole;
            Clear();
            DrawBorder();
            string redControl = GetColorControlString(TCODColor.red);
            string stopControl = GetStopControl();
            PrintString(1, 1, string.Format("{0}Passives:{1}", redControl, stopControl));

            var passiveBuilder = new StringBuilder();
            IList<IAffliction> passives = model.CharacterFactory.GetPassives(character);
            int[] count = { 0 };
            foreach (IAffliction passive in passives.Where(passive => count[0] != 4))
            {
                passiveBuilder.AppendLine(passive.Name).AppendLine();
                ++count[0];
            }

            PrintString(3, 3, passiveBuilder.ToString());
            PrintString(1, 11, string.Format("{0}Afflictions:{1}", redControl, stopControl));

            IList<IAffliction> afflictions = RHelper.ScriptHelper.GetAfflictions(character);
            count[0] = 13;
            string orangeControl = GetColorControlString(TCODColor.orange);
            string greenControl = GetColorControlString(TCODColor.green);

            foreach (IAffliction affliction in afflictions)
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