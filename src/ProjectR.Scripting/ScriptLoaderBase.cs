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

            var resultList = new List<T>();
            foreach (var file in Directory.EnumerateFiles(ScriptPath).Select(x => new FileInfo(x)).Where(x => x.Extension == ".cs"))
            {
                resultList.AddRange(LoadScript(file, updateAction, totalCount, ++currentCount));
            }

            return resultList;
        }

        protected virtual IEnumerable<T> LoadScript(FileSystemInfo file, UpdateLoadResourcesDelegate updateAction, int totalCount, int currentCount)
        {
            updateAction(string.Format("Compiling: {0}", file.Name), currentCount, totalCount);
            var assembly = CSScript.Load(file.ToString(), null, true);
            var helper = new AsmHelper(assembly);

            return assembly.ExportedTypes
                           .Where(x => x.GetInterfaces().Contains(typeof (T)))
                           .Select(source => (T) helper.CreateObject(source.FullName));
        }
    }
}