namespace ProjectR.Interfaces.Model
{
    public interface ISpellFactory
    {
        void LoadSpells();
        ISpell GetSpell(string name);
        ISpell GetRandomSpell();
    }
}