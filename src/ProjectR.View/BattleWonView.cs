using libtcod;

namespace ProjectR.View
{
    public class BattleWonView : InitializeableModelStateWithConsole
    {
        private const string StaticString = "Battle Summary:\n\n" +
                                            "Base XP gained:\n\n" +
                                            "Convert bonus:\n\n" +
                                            "Total XP gained:\n\n" +
                                            "Intact Cores salvaged:\n\n" +
                                            "Unstable Cores salvaged:\n\n";

        private const string FormatString = "{0}\n\n" +
                                            "{1}\n\n" +
                                            "{2}\n\n" +
                                            "{3}\n\n" +
                                            "{4}\n\n";

        public BattleWonView()
            : base(33, 15)
        {
        }

        public override void Run()
        {
            Clear();
            DrawBorder();

            var battleModel = Model.BattleModel;
            var pack = battleModel.CurrentMobPack;
            PrintString(2, 2, StaticString);

            var baseXP = pack.XPReward;
            var convertBonus = battleModel.Enemies.Count == 1 ? pack.GetConvertBonus(battleModel.Enemies[0]) : 1f;
            var totalXP = baseXP * convertBonus;
            var intactCores = pack.IntactCoreCount;
            var unstableCores = pack.UnstableCoreCount;

            PrintString(30, 4, FormatString, TCODAlignment.RightAlignment, baseXP, convertBonus.ToString("F1"), totalXP,
                intactCores, unstableCores);

            RConsole.RootConsole.Blit(this, Bounds, 24, 20);
        }
    }
}