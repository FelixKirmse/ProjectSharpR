using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SkillsetFactory : ISkillsetFactory
    {
        public IList<ISkillset> SkillSets { get; private set; }
        private readonly IModel _model;
        private readonly Dictionary<string, ISkillset> _nameMap;

        public SkillsetFactory(IModel model)
        {
            _model = model;
            SkillSets = new List<ISkillset>();
            _nameMap = new Dictionary<string, ISkillset>();
        }

        public void LoadSkillsets()
        {
            throw new System.NotImplementedException();
        }

        public ISkillset GetSkillset(string name)
        {
            return _nameMap[name];
        }
    }
}