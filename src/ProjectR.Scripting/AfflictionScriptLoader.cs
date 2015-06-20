using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class AfflictionScriptLoader : ScriptLoaderBase<IAffliction>
    {
        protected override string ScriptPath { get { return _currentPath; } }
        private string _currentPath;

        public IEnumerable<IAffliction> LoadAllScripts(UpdateLoadResourcesDelegate updateAction)
        {
            _currentPath = "afflictions/Buffs";
            foreach (var buff in LoadScripts(updateAction))
            {
                yield return buff;
            }

            _currentPath = "afflictions/Debuffs";
            foreach(var debuff in LoadScripts(updateAction))
            {
                yield return debuff;
            }

            _currentPath = "afflictions/Passives";
            foreach (var passive in LoadScripts(updateAction))
            {
                yield return passive;
            }
        }
    }
}