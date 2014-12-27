using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Scripting
{
    public class ScriptLoader : IScriptLoader
    {
        private readonly RaceScriptLoader _raceScriptLoader = new RaceScriptLoader();

        public IEnumerable<IRaceTemplate> LoadRaceTemplates()
        {
            return _raceScriptLoader.LoadScripts();
        }
    }
}