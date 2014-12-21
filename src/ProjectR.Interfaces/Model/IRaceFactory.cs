using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IRaceFactory
    {
        IList<IRaceTemplate> Templates { get; } 

        void LoadTemplates();
        IRaceTemplate GetTemplate(string name);
        IRaceTemplate GetRandomTemplate();

        IList<IAffliction> GetPassivesForRace(string race);
    }
}