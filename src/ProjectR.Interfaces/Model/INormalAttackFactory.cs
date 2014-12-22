using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface INormalAttackFactory
    {
        IList<ISpell> NormalAttacks { get; set; }

        void LoadNormalAttacks();
    }
}