using System;

namespace ProjectR.Interfaces.Helper
{
    public enum ErrorCodes
    {
        LuaErrorReload = 129,
        LuaErrorBinding = 130,
        LuaErrorAssigning = 131,
        LuaErrorCasting = 132,
        LuaErrorAttaching = 133,
        LuaErrorRemoving = 134,
        LuaErrorHooktrigger = 135,
        ErrorSpellNotFound = 150,
        ErrorTemplateNotFound = 151,
        ErrorCharLimitReachedFrontrow = 152,
        ErrorCharLimitReachedBackseat = 153,
        ErrorCharLimitReachedReserve = 154,
        ErrorAfflictionNotFound = 155,
        ErrorCharparseFailed = 156,
        ErrorRaceparseFailed = 157,
        ErrorArcheparseFailed = 158,
        ErrorSkillparseFailed = 159,
        UnknownError = 255
    }

    public static class ExitHelper
    {
        public static Action ExitAction { get; set; }

        public static void Exit()
        {
            ExitAction();
        }

        public static void Exit(ErrorCodes exitCode, string reason)
        {
            Console.Error.WriteLine(reason);
            Environment.Exit((int) exitCode);
        }
    }
}