using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class AfflictionScriptLoader : ScriptLoaderBase<IAffliction>
    {
        protected override string ScriptPath { get { return "Afflictions"; } }
    }
}