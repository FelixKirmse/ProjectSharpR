using System;
using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SkillsetFactory : ISkillsetFactory
    {
        private readonly IModel _model;
        private readonly Dictionary<string, ISkillset> _nameMap;

        public SkillsetFactory(IModel model)
        {
            _model = model;
            SkillSets = new List<ISkillset>();
            _nameMap = new Dictionary<string, ISkillset>();
        }

        public IList<ISkillset> SkillSets { get; private set; }

        public void LoadSkillsets()
        {
            throw new NotImplementedException();
        }

        public ISkillset GetSkillset(string name)
        {
            return _nameMap[name];
        }
    }
}