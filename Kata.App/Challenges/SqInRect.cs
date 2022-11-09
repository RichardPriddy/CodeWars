using System;
using System.Collections.Generic;

namespace CodeWars.App.Challenges
{
    public class SqInRect
    {
        public static List<int> sqInRect(int lng, int wdth, List<int> ints = null)
        {
            if (lng > 1 && lng == wdth && ints == null) return ints;
            var shortSide = Math.Min(lng, wdth);
            var longSide = Math.Max(lng, wdth);

            ints ??= new List<int>();

            ints.Add(shortSide);

            if (shortSide == 1 && longSide == 1 || shortSide == longSide)
                return ints;

            return sqInRect(shortSide, longSide - shortSide, ints);
        }
    }
}
