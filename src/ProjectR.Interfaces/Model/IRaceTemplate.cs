using System.Collections.Generic;
using ProjectR.Interfaces.Helper;

namespace ProjectR.Interfaces.Model
{
    public interface IRaceTemplate
    {
        string Description { get; }
        string Name { get; }

        IList<string> Passives { get; }
        IRaceDictionary Stats { get; } 
    }
}