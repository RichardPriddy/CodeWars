using System.Collections.Generic;
using System.Linq;

namespace CodeWars.App.Challenges
{
    class Permutations
    {
        public static List<string> SinglePermutations(string s)
        {
            static void Swap(ref char a, ref char b)
            {
                if (a == b) return;

                var temp = a;
                a = b;
                b = temp;
            }

            static IEnumerable<string> GetPermutations(char[] letters, int swapCharactersFromIndex, int lengthOfInputString)
            {
                if (swapCharactersFromIndex == lengthOfInputString)
                {
                    yield return new string(letters);
                }
                else
                    for (int i = swapCharactersFromIndex; i <= lengthOfInputString; i++)
                    {
                        Swap(ref letters[swapCharactersFromIndex], ref letters[i]);
                        foreach (var x in GetPermutations(letters, swapCharactersFromIndex + 1, lengthOfInputString)) yield return x;
                        Swap(ref letters[swapCharactersFromIndex], ref letters[i]);
                    }
            }

            var letters = s.ToCharArray();

            int x = letters.Length - 1;
            var vals = GetPermutations(letters, 0, x);

            return vals.Distinct().ToList();
        }
    }
}
