using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class TitleModel : ITitleModel
    {
        public TitleModel()
        {
            TitleScreen = new TCODImage("content/images/logo.png");
        }

        public TCODImage TitleScreen { get; private set; }
    }
}