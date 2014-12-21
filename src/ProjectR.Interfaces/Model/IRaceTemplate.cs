using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public interface IRaceTemplate
    {
        double this[Stat stat] { get; set; }
        string Description { get; set; }
        string Name { get; set; }
    }
}