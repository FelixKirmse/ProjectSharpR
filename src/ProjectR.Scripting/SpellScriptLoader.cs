using ProjectR.Interfaces;

namespace ProjectR.Scripting
{
    public class SpellScriptLoader : ScriptLoaderBase<ISpell>
    {
        protected override string ScriptPath { get { return "Spells"; } }
    }
}