using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SignatureSpellFactory : ISignatureSpellFactory
    {
        public IList<ISpell> GetSignatureSpells { get; private set; }
        private readonly IModel _model;

        public SignatureSpellFactory(IModel model)
        {
            _model = model;
        }

        public void LoadSignatureSpells()
        {
            throw new System.NotImplementedException();
        }
    }
}