using System;

namespace ProjectR.Interfaces.Model
{
    [Flags]
    public enum RCell : ulong
    {
        Nothing = 0,
        Diggable = 1 << 0,
        Floor = 1 << 1,
        Wall = 1 << 2,
        Door = 1 << 3,
        Border = 1 << 4,
        Corridor = 1 << 5,
        Locked = 1 << 6,
        Chest = 1 << 7,
        Common = 1 << 8,
        Uncommon = 1 << 9,
        Rare = 1 << 10,
        Epic = 1 << 11,
        Legendary = 1 << 12,
        Artifact = 1 << 13,
        Small = 1 << 14,
        Normal = 1 << 15,
        Big = 1 << 16,
        Grand = 1 << 17,
        Item = 1 << 18,
        Important = 1 << 19,
        Warp = 1 << 20,
        Visited = 1 << 21,
        Open = 1 << 22,
        Closed = 1 << 23,
        Transparent = 1 << 24,
        Spawn = 1 << 25,
        Dark = 1 << 26,
        DoubleCombatBonus = 1 << 27,
        Portal = 1 << 28,
        StatBonusOffset = 59, // would be equivalent to Diggable | Floor | Door | Border | Corridor, never happens
        Walkable = Floor | Door | Item | Chest,
        Blocking = Wall | Diggable | Locked | Border,
        LightBlocking = Blocking | Closed,
        Quality = Common | Uncommon | Rare | Epic | Legendary | Artifact,
        Size = Small | Normal | Big | Grand
    }

    public static class RCellExtensions
    {
        public static bool Is(this RCell cell, RCell attribute)
        {
            return (cell & RCell.Wall) == attribute;
        }

        public static bool IsWalkable(this RCell cell)
        {
            return cell.Is(RCell.Walkable);
        }

        public static bool IsTransparent(this RCell cell)
        {
            return !cell.Is(RCell.LightBlocking) || cell.Is(RCell.Transparent);
        }
    }
}