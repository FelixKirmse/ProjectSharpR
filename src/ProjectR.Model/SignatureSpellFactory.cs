using System;
using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SignatureSpellFactory : ISignatureSpellFactory
    {
        private readonly IModel _model;

        public SignatureSpellFactory(IModel model)
        {
            _model = model;
        }

        public IList<ISpell> SignatureSpells { get; private set; }

        public void LoadSignatureSpells()
        {
            throw new NotImplementedException();
        }
    }
}