using System;
using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class RaceFactory : IRaceFactory
    {
        private readonly IModel _model;
        private readonly Dictionary<string, List<IAffliction>> _passives;
        private readonly Dictionary<string, int> _stringIndexMap;

        public RaceFactory(IModel model)
        {
            _model = model;
            Templates = new List<IRaceTemplate>();
            _stringIndexMap = new Dictionary<string, int>();
            _passives = new Dictionary<string, List<IAffliction>>();
        }

        public IList<IRaceTemplate> Templates { get; private set; }

        public void LoadTemplates()
        {
            throw new NotImplementedException();
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