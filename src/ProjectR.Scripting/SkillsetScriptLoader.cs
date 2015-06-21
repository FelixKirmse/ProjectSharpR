using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class SkillsetScriptLoader : ScriptLoaderBase<ISkillset>
    {
        protected override string ScriptPath { get { return "SkillSets"; } }
    }
}