using System;
using System.Linq;

namespace CodeWars.App.Challenges
{
    /* 3 rails:
     W       E       C       R       L       T       E
       E   R   D   S   O   E   E   F   E   A   O   C  
         A       I       V       D       E       N    
     */

    public class RailFenceCipher
    {
        public static string Encode(string s, int n)
        {
            var rails = new string[n];
            var sChars = s.ToCharArray();

            var railTracker = 0;
            var railDirection = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (railDirection)
                {
                    rails[railTracker] += sChars[i];
                    if (railTracker < n - 1)
                        railTracker++;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker--;
                    }
                }
                else if (!railDirection)
                {
                    rails[railTracker] += sChars[i];
                    if (railTracker > 0)
                        railTracker--;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker++;
                    }
                }
            }

            // Your code here
            return string.Concat(rails);
        }

        public static string Decode(string s, int n)
        {
            // Determine the length of each of the rails
            var railLenghts = new int[n];
            var railTracker = 0;
            var railDirection = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (railDirection)
                {
                    railLenghts[railTracker]++;
                    if (railTracker < n - 1)
                        railTracker++;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker--;
                    }
                }
                else if (!railDirection)
                {
                    railLenghts[railTracker]++;
                    if (railTracker > 0)
                        railTracker--;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker++;
                    }
                }
            }

            // Split the input string into each rail
            var rails = new string[n];
            var railPositionTracker = 0;
            for (int i = 0; i < n; i++)
            {
                rails[i] = s.Substring(railPositionTracker, railLenghts[i]);
                railPositionTracker += railLenghts[i];
            }

            // Run across each rail rebuilding the string
            var output = "";
            railTracker = 0;
            railDirection = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (railDirection)
                {
                    var rail = rails[railTracker].ToCharArray();
                    output += rail[0];
                    rails[railTracker] = string.Concat(rail.Skip(1));
                    if (railTracker < n - 1)
                        railTracker++;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker--;
                    }
                }
                else if (!railDirection)
                {
                    var rail = rails[railTracker].ToCharArray();
                    output += rail[0];
                    rails[railTracker] = string.Concat(rail.Skip(1));
                    if (railTracker > 0)
                        railTracker--;
                    else
                    {
                        railDirection = !railDirection;
                        railTracker++;
                    }
                }
            }

            return output;
        }
    }
}
