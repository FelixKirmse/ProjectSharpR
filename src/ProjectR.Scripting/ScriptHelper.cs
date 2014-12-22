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
    }
}