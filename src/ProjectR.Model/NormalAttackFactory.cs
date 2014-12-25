using System;
using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class NormalAttackFactory : INormalAttackFactory
    {
        private readonly IModel _model;

        public NormalAttackFactory(IModel model)
        {
            _model = model;
        }

        public IList<ISpell> NormalAttacks { get; set; }

        public void LoadNormalAttacks()
        {
            throw new NotImplementedException();
        }
    }
}