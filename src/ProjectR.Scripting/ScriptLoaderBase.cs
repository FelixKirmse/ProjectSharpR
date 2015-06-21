using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
                return Directory.EnumerateFiles(CompletePath, "*.cs", SearchOption.AllDirectories)
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
            foreach (
                var file in
                    Directory.EnumerateFiles(CompletePath, "*.cs", SearchOption.AllDirectories)
                             .Select(x => new FileInfo(x))
                             .Where(x => x.Extension == ".cs"))
            {
                resultList.AddRange(LoadScript(file, updateAction, totalCount, ++currentCount));
            }

            return resultList;
        }

        protected virtual IEnumerable<T> LoadScript(FileSystemInfo file, UpdateLoadResourcesDelegate updateAction,
                                                    int totalCount, int currentCount)
        {
            var assemblyPath = Path.Combine(CompleteCompiledScriptPath, Path.ChangeExtension(file.Name, ".dll"));
            var md5Path = Path.Combine(CompleteCompiledScriptPath, Path.ChangeExtension(file.Name, ".md5"));

            Assembly assembly;
            if (ScriptNeedsCompilation(file, assemblyPath, md5Path))
            {
                updateAction(string.Format("Compiling: {0}", file.Name), currentCount, totalCount);
                assembly = CSScript.Load(file.ToString(), assemblyPath, false);
            }
            else
            {
                updateAction(string.Format("Loading: {0}", Path.GetFileName(Path.ChangeExtension(file.Name, ".dll"))),
                    currentCount, totalCount);
                assembly = Assembly.LoadFrom(assemblyPath);
            }

            var helper = new AsmHelper(assembly);

            return assembly.ExportedTypes
                           .Where(x => x.GetInterfaces().Contains(typeof (T)))
                           .Select(source => (T) helper.CreateObject(source.FullName));
        }

        private static bool ScriptNeedsCompilation(FileSystemInfo script, string assemblyPath, string md5Path)
        {
            if (!File.Exists(assemblyPath) || !File.Exists(md5Path))
            {
                var md5 = ComputeHash(script.ToString());
                SaveHashFile(md5, md5Path);
                return true;
            }

            var oldMd5 = ReadHashFile(md5Path);
            var currentMd5 = ComputeHash(script.ToString());

            return !oldMd5.SequenceEqual(currentMd5);
        }

        private static void SaveHashFile(byte[] md5, string md5Path)
        {
            using (var stream = File.OpenWrite(md5Path))
            {
                stream.Write(md5, 0, md5.Length);
            }
        }

        private static IEnumerable<byte> ReadHashFile(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }

        public static byte[] ComputeHash(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
    }
}