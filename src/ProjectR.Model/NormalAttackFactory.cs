using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class NormalAttackFactory : FactoryBase, INormalAttackFactory
    {
        public NormalAttackFactory(IModel model)
        {
            Model = model;
        }

        public IList<ISpell> NormalAttacks { get; set; }

        public void LoadNormalAttacks()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading NormalAttacks";
            NormalAttacks =
                File.ReadAllLines("content/scripts/normalattacks/normalattacks.cfg")
                    .Select(x => Model.SpellFactory.GetSpell(x))
                    .ToList();
        }
    }
}