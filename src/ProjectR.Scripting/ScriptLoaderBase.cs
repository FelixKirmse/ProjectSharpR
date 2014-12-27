using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSScriptLibrary;

namespace ProjectR.Scripting
{
    public abstract class ScriptLoaderBase<T>
        where T : class 
    {
        protected abstract string ScriptPath { get; }

        public IEnumerable<T> LoadScripts()
        {
            return from file in Directory.EnumerateFiles(ScriptPath).Select(x => new FileInfo(x))
                   where file.Extension == ".cs"
                   select LoadScript(file);
        }

        protected virtual T LoadScript(FileSystemInfo file)
        {
            var helper = new AsmHelper(CSScript.Load(file.ToString(), null, true));

            var race = (T) helper.CreateObject(string.Format("ProjectR.Scripting.{0}", Path.GetFileNameWithoutExtension(file.Name)));
            return race;
        }
    }
}