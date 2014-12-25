using System.Collections.Generic;
using System.Drawing;

namespace ProjectR.Interfaces.Model
{
    public interface IMobPack
    {
        MobPackStrength Strength { get; }
        Point Position { get; set; }
        int XPReward { get; set; }
        int SightRadius { get; set; }
        int Size { get; }
        int IntactCoreCount { get; }
        int UnstableCoreCount { get; }

        IList<ICharacter> Enemies { get; }
        IList<ICharacter> Minions { get; }

        void AddEnemy(ICharacter enemy, MobPackStrength strength = MobPackStrength.Stronger, double convertBonus = 1.2d);
        void AddMinion(ICharacter minion);
        void SetConvertBonus(ICharacter character, double bonus);
        double GetConvertBonus(ICharacter character);
        bool ProcessTurn(int playerX, int playerY);
        void SetStrength(ICharacter enemy, MobPackStrength strength);
        MobPackStrength GetStrength(ICharacter enemy);
    }
}