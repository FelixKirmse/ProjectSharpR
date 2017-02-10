using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class ArcheTypeScriptLoader : ScriptLoaderBase<IArcheType>
    {
        protected override string ScriptPath { get { return "Archetypes"; } }
    }
}