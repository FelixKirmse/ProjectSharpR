namespace ProjectR.Interfaces.View
{
    public interface ISpellDescriptionDrawer
    {
        void SetPosition(int x, int y);
        void DrawSpellDescription(ISpell spell, IRConsole target = null);
    }
}