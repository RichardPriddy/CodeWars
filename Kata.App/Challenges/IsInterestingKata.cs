using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CodeWars.App.Challenges
{
    public static partial class Kata
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            var uninteresting = 0;
            var almostInteresting = 1;
            var interesting = 2;

            // Perform interesting tests first as they take prescedent over almost interesting
            if (awesomePhrases.Contains(number)) return interesting;
            if (number.AreAllCharactersAreTheSame()) return interesting;
            if (number.AreAllSubsequentNumbersAre0()) return interesting;
            if (number.IsPalendromic()) return interesting;
            if (number.IsAscending()) return interesting;
            if (number.IsDescending()) return interesting;

            if (awesomePhrases.Any(a => a.IsAlmostInteresting(number))) return almostInteresting;
            if (number.Almost(AreAllCharactersAreTheSame)) return almostInteresting;
            if (number.Almost(AreAllSubsequentNumbersAre0)) return almostInteresting;
            if (number.Almost(IsPalendromic)) return almostInteresting;
            if (number.Almost(IsAscending)) return almostInteresting;
            if (number.Almost(IsDescending)) return almostInteresting;

            return 0;
        }

        private static bool Almost(this int number, Func<int, bool> func)
        {
            return func(number + 1) || func(number + 2);
        }

        private static bool IsAscending(this int number)
        {
            if (number < 100) return false;
            var numbers = number.ToString().ToCharArray().Select(i => (int)char.GetNumericValue(i)).ToArray();
            var n = numbers.First();
            for(int i =1; i< numbers.Count(); i++)
            {
                var comp = n + 1;
                if(comp == 10) comp = 0;

                if (numbers[i] != comp) return false;
                n = numbers[i];
            }
            return true;
        }

        private static bool IsDescending(this int number)
        {
            if (number < 100) return false;
            var numbers = number.ToString().ToCharArray().Select(i => (int)char.GetNumericValue(i)).ToArray();
            var n = numbers.First();
            for (int i = 1; i < numbers.Count(); i++)
            {
                if (numbers[i] != n - 1) return false;
                n = numbers[i];
            }
            return true;
        }

        private static bool IsPalendromic(this int number)
        {
            if (number < 100) return false;
            var numberString = number.ToString();
            int halfLength = numberString.Length / 2;

            for (int i = 0; i <= halfLength; i++)
            {
                if (numberString[i] != numberString[numberString.Length - i - 1]) return false;
            }

            return true;
        }

        private static bool AreAllSubsequentNumbersAre0(this int number)
        {
            if (number < 100) return false;
            return string.Concat(number.ToString().ToCharArray().Skip(1).Distinct()) == "0";
        }

        private static bool AreAllCharactersAreTheSame(this int number)
        {
            if (number < 100) return false;
            return number.ToString().ToCharArray().Distinct().Count() == 1;
        }

        private static bool IsAlmostInteresting(this int a, int number)
        {
            if (number < 100) return false;
            return a - 2 <= number && a > number;
        }

        private static bool IsLessThan(this int number, int threshold)
        {
            return number < threshold;
        }
    }
}
