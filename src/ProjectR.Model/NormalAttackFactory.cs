using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class NormalAttackFactory : INormalAttackFactory
    {
        public IList<ISpell> NormalAttacks { get; set; }
        private readonly IModel _model;

        public NormalAttackFactory(IModel model)
        {
            _model = model;
        }

        public void LoadNormalAttacks()
        {
            throw new System.NotImplementedException();
        }
    }
}