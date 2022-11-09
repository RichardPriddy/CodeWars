using System.Collections.Generic;
using System.Linq;

namespace CodeWars.App.Challenges
{
    public class RomanDecode
    {
        private static Dictionary<char, int> romans = new Dictionary<char, int> {
                                                                                {'I', 1},
                                                                                {'V', 5},
                                                                                {'X', 10},
                                                                                {'L', 50},
                                                                                {'C', 100},
                                                                                {'D', 500},
                                                                                {'M', 1000 }
                                                                            };

        public static int Solution(string roman)
        {
            var numbers = roman.ToCharArray().Select(c => romans[c]).ToArray();
            var year = 0;
            var next = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                next = i + 1 == numbers.Count() ? 0 : numbers[i + 1];

                if (numbers[i] >= next)
                {
                    year = year + numbers[i];
                }
                else
                {
                    year = year + next - numbers[i];
                    i++;
                }
            }

            return year;
        }
    }
}
