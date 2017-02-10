using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces
{
    public interface IGenerator
    {
        bool Generate(int row, int col, Direction direction);
        void EnableEnemySpawning(IMobPackManager mobPackManager, int chance);
    }
}