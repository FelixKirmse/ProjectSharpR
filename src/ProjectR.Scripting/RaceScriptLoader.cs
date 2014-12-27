using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class RaceScriptLoader : ScriptLoaderBase<IRaceTemplate>
    {
        protected override string ScriptPath { get { return "content/scripts/races"; } }
    }
}