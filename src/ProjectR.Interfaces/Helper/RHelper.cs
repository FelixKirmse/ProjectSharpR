using System;
using System.Collections.Generic;

namespace ProjectR.Interfaces.Helper
{
    public static class RHelper
    {
        private static readonly Random Random = new Random();

        public static IList<T> ShuffleList<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                --n;
                var k = Random.Next(0, n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static void MoveInDirection(ref int row, ref int col, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    row -= 1;
                    break;

                case Direction.East:
                    col += 1;
                    break;

                case Direction.South:
                    row += 1;
                    break;

                case Direction.West:
                    col -= 1;
                    break;

                case Direction.Center:
                    break;

                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        public static int Roll(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static int Roll(int max)
        {
            return Roll(0, max);
        }

        public static int MakeEven(this int n)
        {
            return n%2 == 0 ? n : n + 1;
        }

        public static int MakeOdd(this int n)
        {
            return n%2 == 0 ? n + 1 : n;
        }

        public static Direction GetRandomDirection()
        {
            return (Direction) Roll((int) Direction.West);
        }

        public static bool RollPercentage(int percentageChance)
        {
            return Roll(0, 99) < percentageChance;
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            return val.CompareTo(max) > 0 ? max : val;
        }


        private static readonly Direction[] Directions =
        {
            Direction.North, Direction.East, Direction.South, Direction.West, Direction.Center
        
        }; 

        public static Direction[] GetDirections()
        {
            return Directions.Clone() as Direction[];
        }
    }
}