using System;
using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class ArcheTypeFactory : IArcheTypeFactory
    {
        private readonly IModel _model;
        private readonly Dictionary<string, IArcheType> _nameMap;

        public ArcheTypeFactory(IModel model)
        {
            _model = model;
            ArcheTypes = new List<IArcheType>();
            _nameMap = new Dictionary<string, IArcheType>();
        }

        public IList<IArcheType> ArcheTypes { get; private set; }

        public void LoadArcheTypes()
        {
            throw new NotImplementedException();
        }

        public IArcheType GetArcheType(string name)
        {
            return _nameMap[name];
        }
    }
}