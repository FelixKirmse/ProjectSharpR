using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Spellfactory : FactoryBase, ISpellFactory
    {
        private readonly Dictionary<string, ISpell> _nameMap;
        private List<ISpell> _spells;

        public Spellfactory(IModel model)
        {
            Model = model;
            _nameMap = new Dictionary<string, ISpell>();
        }

        public void LoadSpells()
        {
            Model.LoadResourcesModel.OverarchingAction = "Loading Spells";
            _spells = RHelper.ScriptLoader.LoadSpells(UpdateModel).ToList();

            foreach (var spell in _spells)
            {
                _nameMap.Add(spell.Name.ToLower(), spell);
            }
        }

        public ISpell GetSpell(string name)
        {
            name = name.ToLower();
            if (!_nameMap.ContainsKey(name))
            {
                ExitHelper.Exit(ErrorCodes.ErrorSpellNotFound, "Spell not found " + name);
            }

            return _nameMap[name];
        }

        public ISpell GetRandomSpell()
        {
            ISpell spell;

            do
            {
                spell = _spells[RHelper.Roll(_spells.Count - 1)];
            } while (spell.Name == "Attack" || spell.Name == "Defend" || spell.Name == "Switch");

            return spell;
        }
    }
}