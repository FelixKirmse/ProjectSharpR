using ProjectR.Interfaces.Model;

namespace ProjectR.Interfaces.View
{
    public interface ICharBattleFrame
    {
        void SetPosition(int x, int y);
        void AssignCharacter(ICharacter character, MobPackStrength strength = MobPackStrength.Equal);
        void Draw();
    }
}