using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class AfflictionFactory : IAfflictionFactory
    {
        private const string ScriptPath = "content/scripts/afflictions";

        private readonly Dictionary<string, IAffliction> _afflictions;
        private readonly IModel _model;

        public AfflictionFactory(IModel model)
        {
            _model = model;
            _afflictions = new Dictionary<string, IAffliction>();
        }

        public void LoadAfflictions()
        {
            LoadFrom(ScriptPath + "/Buffs");
            LoadFrom(ScriptPath + "/Debuffs");
            LoadFrom(ScriptPath + "/Passives");
        }

        public IAffliction GetAffliction(string name)
        {
            if (!_afflictions.ContainsKey(name))
            {
                ExitHelper.Exit(ErrorCodes.ErrorAfflictionNotFound, "Affliction not found " + name);
            }

            return _afflictions[name];
        }

        public void RemoveAllAfflictions()
        {
            _afflictions.Clear();
        }

        private void LoadFrom(string path)
        {
            foreach (IAffliction affl in from file in Directory.EnumerateFiles(path)
                                         let fileInfo = new FileInfo(file)
                                         where fileInfo.Extension == "cs"
                                         select Factories.RFactory.CreateScriptedAffliction(_model, file))
            {
                _afflictions[affl.Name] = affl;
            }
        }
    }
}