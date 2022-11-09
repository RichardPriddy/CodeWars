using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CodeWars.App.Challenges
{
    public partial class Kata
    {
        public static bool Solution(string str, string ending)
        {
            return str.EndsWith(ending);
        }

        public static int TrailingZeros(int n)
        {
            BigInteger fact = 1;
            for (int x = 1; x <= n; x++)
            {
                fact *= x;
            }

            var zeros = Regex.Match(fact.ToString(), "[0]*$");

            return zeros.Length;
        }

        public static int Score(int[] dice)
        {
            static int Calc(IGrouping<int, int> i)
            {
                if (i.Key == 10 || i.Key == 5)
                    return i.Count() == 3 ? i.Key * 100 : i.Key * 110;
                else
                    return i.Key * 100;
            }

            return dice.Select(i => i == 1 ? 10 : i)
                       .GroupBy(i => i)
                       .Where(i => i.Key == 10 || i.Key == 5 || i.Count() >= 3)
                       .Sum(i => i.Count() >= 3 ? Calc(i) : i.Key * 10 * i.Count());

        }

        public static string PigIt(string str)
        {
            return string.Join(" ", str.Split(" ").Select(i => string.Concat(i.ToArray().Skip(1)) + i.ToArray()[0] + (i.Any(i => !char.IsLetter(i)) ? "" : "ay")));
        }

        public static char FindMissingLetter(char[] array)
        {
            return (char)Enumerable.Range(array[0], array[array.Length - 1] - array[0]).Except(array.Select(i => (int)i)).Single();
        }

        public static string Justify(string str, int len)
        {
            if (str == null) return "";
            if (len <= 0) return "";
            var words = str.Split(" ");
            var lines = new List<List<string>>();
            foreach (var word in words)
            {
                if (!lines.Any() || lines.Last().Sum(i => i.Length) + word.Length + lines.Last().Count() > len)
                {
                    lines.Add(new List<string> { word });
                }
                else
                {
                    lines.Last().Add(word);
                }
            }

            for (int j = 0; j < lines.Count; j++)
            {
                int spaces = len - lines[j].Sum(i => i.Length);
                if (lines[j].Count() == 1) continue;
                var wordCounter = 0;
                for (int i = 0; i < spaces; i++)
                {
                    lines[j][wordCounter] += " ";
                    wordCounter++;
                    if (wordCounter >= lines[j].Count() - 1)
                    {
                        if (j == lines.Count - 1) break;

                        wordCounter = 0;
                    }
                }
            }

            return string.Join('\n', lines.Select(i => string.Concat(i))).Trim();
        }

        public static long NextBiggerNumber(long n)
        {
            if (n < 10) return -1;

            var checkArr = n.ToString().ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
            var guardArr = (int[])checkArr.Clone();
            Array.Sort(checkArr);
            if (checkArr.Reverse().SequenceEqual(guardArr)) return -1;
            var cont = true;
            do
            {
                n += 1;
                var numArr = n.ToString().ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
                Array.Sort(numArr);
                if (checkArr.SequenceEqual(numArr))
                {
                    return n;
                }
                if (checkArr.Count() != numArr.Count()) return -1;
            } while (cont);

            return -1;
        }

        public static string sumStrings(string a, string b)
        {
            static int[] toArray(string s)
            {
                return s.ToCharArray().Select(a => int.Parse(a.ToString())).Reverse().ToArray();
            }
            static int add(int sum, out int carry)
            {
                if (sum > 9)
                {
                    var toAdd = sum % 10;
                    carry = (sum - toAdd) / 10;
                    return toAdd;
                }
                else
                {
                    carry = 0;
                    return sum;
                }
            }

            var numA = a.Length > b.Length ? toArray(a) : toArray(b);
            var numB = a.Length > b.Length ? toArray(b) : toArray(a);
            var carry = 0;
            var str = "";

            for (int i = 0; i < numB.Count(); i++)
            {
                str = add(numA[i] + numB[i] + carry, out carry) + str;
            }
            for (int i = numB.Count(); i < numA.Count(); i++)
            {
                str = add(numA[i] + carry, out carry) + str;
            }
            if (carry > 0)
            {
                str = carry + str;
            }
            // Fix weird starting 0
            if (str.StartsWith("0"))
            {
                str = str.Remove(0, 1);
            }

            return str;
        }


        public static long QueueTime(int[] customers, int n)
        {
            var tills = Enumerable.Repeat(0, n).ToArray();

            foreach (var customer in customers)
            {
                Array.Sort(tills);
                var i = Array.IndexOf(tills, tills[0]);
                tills[i] += customer;
            }

            Array.Sort(tills);
            return tills[tills.Length - 1];
        }

        public class Word
        {
            public string Letters { get; set; }
            public int Position { get; set; }
        }
        public static string Order(string words)
        {
            Word buildWord(string word)
            {
                var position = Regex.Match(word, @"\d+").Value;
                return new Word { Letters = word, Position = int.Parse(position) };
            }

            var split = string.Join(" ", words.Split(" ").Select(i => buildWord(i)).OrderBy(i => i.Position).Select(i => i.Letters));

            return split;
        }

        public static string ToCamelCase(string str)
        {
            var delimiters = Regex.Matches(str, "[^a-zA-Z]");
            var strings = Split(str, delimiters.Select(s => s.Value).ToArray());
            return strings[0] + string.Concat(strings.Skip(1).Select(s => $"{s[0]}".ToUpper() + string.Concat(s.ToCharArray().Skip(1))));
        }

        public static string[] Split(string str, string[] delimiters)
        {
            var strs = new List<string>();
            if (delimiters.Length == 0) return new[] { str };
            foreach (var s in str.Split(delimiters.First()))
            {
                strs.AddRange(Split(s, delimiters.Skip(1).ToArray()));
            }
            return strs.ToArray();
        }
        public static string SpinWords(string sentence)
        {
            return string.Join(" ", sentence.Split(" ").Select(i => i.Length >= 5 ? string.Concat(i.ToCharArray().Reverse()) : i));
        }
    }
}