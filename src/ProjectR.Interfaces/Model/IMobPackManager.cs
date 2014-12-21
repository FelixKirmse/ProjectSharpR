using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IMobPackManager
    {
        IList<IMobPack> MobPacks { get; }
        int PackCount { get; }

        void ClearPacks();
        void GeneratePack(int x, int y);
        void GenerateBoss(int x, int y);
        void GenerateProjectR(int x, int y);
    }
}