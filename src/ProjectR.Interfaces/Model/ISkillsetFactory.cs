using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface ISkillsetFactory
    {
        IList<ISkillset> SkillSets { get; } 

        void LoadSkillsets();
        ISkillset GetSkillset(string name);
    }
}