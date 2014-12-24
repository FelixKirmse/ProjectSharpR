using System.Collections.Generic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.Helper
{
    public interface IScriptHelper
    {
        void ResetAllAfflictions();
        IList<IAffliction> GetAfflictions(ICharacter character);
    }
}