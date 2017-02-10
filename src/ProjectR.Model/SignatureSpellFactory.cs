using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SignatureSpellFactory : FactoryBase, ISignatureSpellFactory
    {
        public SignatureSpellFactory(IModel model)
        {
            Model = model;
        }

        public IList<ISpell> SignatureSpells { get; private set; }

        public void LoadSignatureSpells()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading SignatureSpells";
            SignatureSpells =
                File.ReadAllLines("content/scripts/SignatureSpells/signaturespells.cfg")
                    .Select(x => Model.SpellFactory.GetSpell(x))
                    .ToList();
        }
    }
}