using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class ScriptHelper : IScriptHelper
    {
        public IModel Model { get; set; }

        public void ResetAllAfflictions()
        {
            Model.AfflictionFactory.RemoveAllAfflictions();
            // TODO CharAfflMap.Clear
        }

        public IList<IAffliction> GetAfflictions(ICharacter character)
        {
            return new IAffliction[0]; // TODO get affliction for character
        }
    }
}