using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Factories;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Spellfactory : ISpellFactory
    {
        private readonly IModel _model;
        private const string ScriptPath = "content/scripts/spells";

        private readonly List<ISpell> _spells;
        private readonly Dictionary<string, ISpell> _nameMap; 
 
        public Spellfactory(IModel model)
        {
            _model = model;
            _spells = new List<ISpell>();
            _nameMap = new Dictionary<string, ISpell>();
        }

        public void LoadSpells()
        {
            foreach (var spell in from file in Directory.EnumerateFiles(ScriptPath)
                                    let fileInfo = new FileInfo(file)
                                    where fileInfo.Extension == "cs"
                                    select Factories.RFactory.CreateScriptedSpell(_model, file))
            {
                _spells.Add(spell);
                _nameMap.Add(spell.Name, spell);
            }
        }

        public ISpell GetSpell(string name)
        {
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