using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class TitleModel : ITitleModel
    {
        public TCODImage TitleScreen { get; private set; }

        public TitleModel()
        {
            TitleScreen = new TCODImage("content/images/logo.png");
        }
    }
}