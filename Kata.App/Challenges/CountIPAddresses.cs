using System.Linq;

namespace CodeWars.App.Challenges
{
    public class CountIPAddresses
    {
        public static long IpsBetween(string start, string end)
        {
            var startParts = start.Split(".").Select(i => long.Parse(i)).ToArray();
            var endParts = end.Split(".").Select(i => long.Parse(i)).ToArray();

            var o1 = (endParts[0] - startParts[0]) * 256 * 256 * 256;
            var o2 = (endParts[1] - startParts[1]) * 256 * 256;
            var o3 = (endParts[2] - startParts[2]) * 256;
            var o4 = endParts[3] - startParts[3];

            return o1 + o2 + o3 + o4;
        }
    }
}
