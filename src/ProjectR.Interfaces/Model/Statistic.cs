namespace ProjectR.Interfaces.Model
{
    public enum Statistic
    {
        StepsTaken, // Taken care of by OverworldPlayer
        MapsGenerated, // Taken care of by OverworldModel
        SquaresRevealed, // Taken care if by MapDrawer
        BattlesFought, // Taken care of by ConsequenceBattleLogic
        EnemiesKilled, // Taken care of by ConsequenceBattleLogic
        EnemiesJoined, // Taken care of by ConvinceLogic
        HighestPartyCount, // Taken care of by Party
        SpellsCast, // Taken care of by ConsequenceBattleLogic
        DamageDone, // Taken care of by ConsequenceBattleLogic
        DamageTaken, // Taken care of by ConsequenceBattleLogic
        HealingTaken, // Taken care of by ConsequenceBattleLogic
        SuccessfulDodges, // Taken care of by ConsequenceBattleLogic
        DamageBlocked, // Taken care of by ConsequenceBattleLogic
        PartyMembersLost, // Taken care of by ConsequenceBattleLogic
        ExperienceEarned, // Taken care of by BattleWonLogic
        CoresFound,
        DoorsOpened, // Taken care of by OverworldPlayer
        ChestsOpened,
        UncommonChestsFound,
        RareChestsFound,
        EpicChestsFound,
        LegendaryChestsFound,
        ArtifactChestsFound,
        NormalChestsFound,
        SmallChestsFound,
        BigChestsFound,
        GrandChestsFound,
        GrandArtifactChestsFound,
        GrandArtifactChestsMissed, //Taken care of by OverworldModel
        StatisticCount
    }
}