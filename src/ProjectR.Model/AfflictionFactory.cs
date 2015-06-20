using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class AfflictionFactory : FactoryBase, IAfflictionFactory
    {
        private readonly Dictionary<string, IAffliction> _afflictions;

        public AfflictionFactory(IModel model)
        {
            Model = model;
            _afflictions = new Dictionary<string, IAffliction>();
        }

        public void LoadAfflictions()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading Afflictions";

            foreach (var affliction in RHelper.ScriptLoader.LoadAfflictions(UpdateModel))
            {
                _afflictions[affliction.Name] = affliction;
            }
        }

        public IAffliction GetAffliction(string name)
        {
            if (!_afflictions.ContainsKey(name))
            {
                ExitHelper.Exit(ErrorCodes.ErrorAfflictionNotFound, "Affliction not found " + name);
            }

            return _afflictions[name];
        }

        public void RemoveAllAfflictions()
        {
            _afflictions.Clear();
        }
    }
}