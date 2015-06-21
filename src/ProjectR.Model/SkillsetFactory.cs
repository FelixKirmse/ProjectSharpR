using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class SkillsetFactory : FactoryBase, ISkillsetFactory
    {
        private readonly Dictionary<string, ISkillset> _nameMap;

        public SkillsetFactory(IModel model)
        {
            Model = model;
            SkillSets = new List<ISkillset>();
            _nameMap = new Dictionary<string, ISkillset>();
        }

        public IList<ISkillset> SkillSets { get; private set; }

        public void LoadSkillsets()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading Skillsets";
            foreach (var skillSet in RHelper.ScriptLoader.LoadSkillsets(UpdateModel))
            {
                SkillSets.Add(skillSet);
                _nameMap.Add(skillSet.Name, skillSet);
            }
        }

        public ISkillset GetSkillset(string name)
        {
            return _nameMap[name];
        }
    }
}