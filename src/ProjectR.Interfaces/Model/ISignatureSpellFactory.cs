using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ISignatureSpellFactory
    {
        IList<ISpell> GetSignatureSpells { get; }

        void LoadSignatureSpells();
    }
}