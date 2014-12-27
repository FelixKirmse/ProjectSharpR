using System.IO;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;

namespace ProjectR.Scripting
{
    public class SpellScriptLoader : ScriptLoaderBase<ISpell>
    {
        protected override string ScriptPath { get { return "content/scripts/spells"; } }

        protected override ISpell LoadScript(FileSystemInfo file)
        {
            var spell =  base.LoadScript(file);
            spell.ScriptHelper = RHelper.ScriptHelper;
            return spell;
        }
    }
}