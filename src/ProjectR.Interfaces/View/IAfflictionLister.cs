using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface IAfflictionLister
    {
        void SetPosition(int x, int y);
        void ListAfflictions(ICharacter character, IModel model, IRConsole target = null);
    }
}