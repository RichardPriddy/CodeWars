using System.Collections.Generic;
using System.Linq;

namespace CodeWars.App.Challenges
{

    public class RomanNumerals
    {
        public static string ToRoman(int n)
        {
            Dictionary<string, int> romans = new Dictionary<string, int> {
                                                                        {"I", 1},
                                                                        {"IV", 4},
                                                                        {"V", 5},
                                                                        {"IX", 9},
                                                                        {"X", 10},
                                                                        {"XL", 40},
                                                                        {"L", 50},
                                                                        {"XC", 90},
                                                                        {"C", 100},
                                                                        {"CD", 400},
                                                                        {"D", 500},
                                                                        {"CM", 900 },
                                                                        {"M", 1000 }
                                                                    };

            var roman = "";

            do
            {
                var value = romans.Where(i => i.Value <= n).Last();
                roman = roman + value.Key;
                n = n - value.Value;
            } while (n > 0);

            return roman;
        }

        public static int FromRoman(string romanNumeral)
        {
            Dictionary<char, int> romans = new Dictionary<char, int> {
                                                                        {'I', 1},
                                                                        {'V', 5},
                                                                        {'X', 10},
                                                                        {'L', 50},
                                                                        {'C', 100},
                                                                        {'D', 500},
                                                                        {'M', 1000 }
                                                                    };
            var numbers = romanNumeral.ToCharArray().Select(c => romans[c]).ToArray();
            var number = 0;
            var next = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                next = i + 1 == numbers.Count() ? 0 : numbers[i + 1];

                if (numbers[i] >= next)
                {
                    number = number + numbers[i];
                }
                else
                {
                    number = number + next - numbers[i];
                    i++;
                }
            }

            return number;
        }
    }
}
