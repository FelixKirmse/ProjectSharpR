using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSScriptLibrary;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public abstract class ScriptLoaderBase<T>
        where T : class 
    {
        protected abstract string ScriptPath { get; }

        public int ScriptCount
        {
            get
            {
                return Directory.EnumerateFiles(ScriptPath)
                                .Select(x => new FileInfo(x)).Count(x => x.Extension == ".cs");
            }
        }

        public IEnumerable<T> LoadScripts(UpdateLoadResourcesDelegate updateAction)
        {
            var totalCount = ScriptCount;
            var currentCount = 0;
            return from file in Directory.EnumerateFiles(ScriptPath).Select(x => new FileInfo(x))
                   where file.Extension == ".cs"
                   select LoadScript(file, updateAction, totalCount, ++currentCount);
        }

        protected virtual T LoadScript(FileSystemInfo file, UpdateLoadResourcesDelegate updateAction, int totalCount, int currentCount)
        {
            updateAction(string.Format("Compiling: {0}", file.Name), currentCount, totalCount);
            var helper = new AsmHelper(CSScript.Load(file.ToString(), null, true));

            var race = (T) helper.CreateObject(string.Format("ProjectR.Scripting.{0}", Path.GetFileNameWithoutExtension(file.Name)));
            return race;
        }
    }
}