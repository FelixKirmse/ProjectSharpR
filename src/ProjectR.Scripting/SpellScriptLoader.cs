using System.IO;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class SpellScriptLoader : ScriptLoaderBase<ISpell>
    {
        protected override string ScriptPath { get { return "content/scripts/spells"; } }

        protected override ISpell LoadScript(FileSystemInfo file, UpdateLoadResourcesDelegate updateAction, int totalCount, int currentCount)
        {
            var spell =  base.LoadScript(file, updateAction, totalCount, currentCount);
            spell.ScriptHelper = RHelper.ScriptHelper;
            return spell;
        }
    }
}