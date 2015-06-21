using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class ArcheTypeFactory : FactoryBase, IArcheTypeFactory
    {
        private readonly Dictionary<string, IArcheType> _nameMap;

        public ArcheTypeFactory(IModel model)
        {
            Model = model;
            ArcheTypes = new List<IArcheType>();
            _nameMap = new Dictionary<string, IArcheType>();
        }

        public IList<IArcheType> ArcheTypes { get; private set; }

        public void LoadArcheTypes()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading Archetypes";
            foreach (var archeType in RHelper.ScriptLoader.LoadArcheTypes(UpdateModel))
            {
                ArcheTypes.Add(archeType);
                _nameMap.Add(archeType.Name, archeType);
            }
        }

        public IArcheType GetArcheType(string name)
        {
            return _nameMap[name];
        }
    }
}