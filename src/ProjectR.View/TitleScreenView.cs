using libtcod;
using ProjectR.Interfaces.Model;

namespace ProjectR.View
{
    public class TitleScreenView : ModelState
    {
        public override void Run()
        {
            Model.TitleModel.TitleScreen.blit2x(TCODConsole.root, 0, 0);
        }
    }
}