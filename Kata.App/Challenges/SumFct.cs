using System.Collections.Generic;
using System.Numerics;

namespace CodeWars.App.Challenges
{
    public class SumFct
    {
        public static BigInteger perimeter(BigInteger n)
        {
            var sum = new BigInteger(0);
            var tracker = new List<BigInteger> { 1, 0 };
            for (int i = 0; i <= n; i++)
            {
                sum += tracker[0];
                tracker[1] = tracker[0] + tracker[1];
                tracker.Reverse();
            }

            return sum * 4;
        }
    }
}
