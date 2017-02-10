using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class RaceFactory : FactoryBase, IRaceFactory
    {
        private readonly Dictionary<string, List<IAffliction>> _passives;
        private readonly Dictionary<string, int> _stringIndexMap;

        public RaceFactory(IModel model)
        {
            Model = model;
            Templates = new List<IRaceTemplate>();
            _stringIndexMap = new Dictionary<string, int>();
            _passives = new Dictionary<string, List<IAffliction>>();
        }

        public IList<IRaceTemplate> Templates { get; private set; }

        public void LoadTemplates()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading Races";
            Templates = RHelper.ScriptLoader.LoadRaceTemplates(UpdateModel).ToList();

            foreach (var raceTemplate in Templates)
            {
                _passives.Add(raceTemplate.Name, new List<IAffliction>());

                _passives[raceTemplate.Name].AddRange(
                    raceTemplate.Passives.Select(x => Model.AfflictionFactory.GetAffliction(x)));
            }
        }

        public IRaceTemplate GetTemplate(string name)
        {
            return Templates[_stringIndexMap[name]];
        }

        public IRaceTemplate GetRandomTemplate()
        {
            return Templates[RHelper.Roll(Templates.Count - 1)];
        }

        public IList<IAffliction> GetPassivesForRace(string race)
        {
            return _passives[race];
        }
    }
}