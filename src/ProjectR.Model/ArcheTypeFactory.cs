using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class ArcheTypeFactory : IArcheTypeFactory
    {
        public IList<IArcheType> ArcheTypes { get; private set; }

        private readonly Dictionary<string, IArcheType> _nameMap; 

        private readonly IModel _model;

        public ArcheTypeFactory(IModel model)
        {
            _model = model;
            ArcheTypes = new List<IArcheType>();
            _nameMap = new Dictionary<string, IArcheType>();
        }

        public void LoadArcheTypes()
        {
            throw new System.NotImplementedException();
        }

        public IArcheType GetArcheType(string name)
        {
            return _nameMap[name];
        }
    }
}