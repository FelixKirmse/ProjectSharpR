using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using CSScriptLibrary;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public abstract class ScriptLoaderBase<T>
        where T : class 
    {
        protected string BaseScriptPath { get { return "content/scripts"; } }

        protected abstract string ScriptPath { get; }

        private string CompletePath { get { return Path.Combine(BaseScriptPath, ScriptPath); } }
        private string CompleteCompiledScriptPath { get { return Path.Combine("compiledscripts", ScriptPath); } }

        public int ScriptCount
        {
            get
            {
                return Directory.EnumerateFiles(CompletePath)
                                .Select(x => new FileInfo(x)).Count(x => x.Extension == ".cs");
            }
        }

        public IEnumerable<T> LoadScripts(UpdateLoadResourcesDelegate updateAction)
        {
            var totalCount = ScriptCount;
            var currentCount = 0;

            if (!Directory.Exists(CompleteCompiledScriptPath))
            {
                Directory.CreateDirectory(CompleteCompiledScriptPath);
            }

            var resultList = new List<T>();
            foreach (var file in Directory.EnumerateFiles(CompletePath).Select(x => new FileInfo(x)).Where(x => x.Extension == ".cs"))
            {
                resultList.AddRange(LoadScript(file, updateAction, totalCount, ++currentCount));
            }

            return resultList;
        }

        protected virtual IEnumerable<T> LoadScript(FileSystemInfo file, UpdateLoadResourcesDelegate updateAction, int totalCount, int currentCount)
        {
            var assemblyPath = Path.Combine(CompleteCompiledScriptPath, Path.ChangeExtension(file.Name, ".dll"));
            Assembly assembly;
            if (ScriptNeedCompilation(file, assemblyPath))
            {
                updateAction(string.Format("Compiling: {0}", file.Name), currentCount, totalCount);
                assembly = CSScript.Load(file.ToString(), assemblyPath, false);
            }
            else
            {
                updateAction(string.Format("Loading: {0}", Path.GetFileName(Path.ChangeExtension(file.Name, ".dll"))), currentCount, totalCount);
                assembly = Assembly.LoadFrom(assemblyPath);
            }

            var helper = new AsmHelper(assembly);

            return assembly.ExportedTypes
                           .Where(x => x.GetInterfaces().Contains(typeof(T)))
                           .Select(source => (T)helper.CreateObject(source.FullName));
        }

        private bool ScriptNeedCompilation(FileSystemInfo script, string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                return true;
            }

            var assemblyInfo = new FileInfo(assemblyPath);

            return script.LastWriteTimeUtc > assemblyInfo.LastWriteTimeUtc;
        }
    }
}