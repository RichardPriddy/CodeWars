using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.App.Challenges
{
    public class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            return string.Join(" ", morseCode.Split("   ").Select(word => string.Concat(word.Split(" ").Select(MorseCode.Get)))).Trim();
        }

        public static string DecodeBits(string bits)
        {
            bits = bits.Trim(new char[] { ' ', '0' });

            var chunks = new List<string>();
            foreach (var c in bits.ToCharArray())
            {
                if (!chunks.Any())
                {
                    chunks.Add(c.ToString());
                }
                else if (chunks.Last()[0] == c)
                {
                    chunks[chunks.Count() - 1] += c.ToString();
                } 
                else
                {
                    chunks.Add(c.ToString());
                }
            }

            var repeater = chunks.OrderBy(i => i.Length).First().Length;

            return bits
                .Replace(string.Concat(Enumerable.Repeat("0000000", repeater)), "   ")
                .Replace(string.Concat(Enumerable.Repeat("000", repeater)), " ")
                .Replace(string.Concat(Enumerable.Repeat("111", repeater)), "-")
                .Replace(string.Concat(Enumerable.Repeat("1", repeater)), ".")
                .Replace(string.Concat(Enumerable.Repeat("0", repeater)), "");
        }

        public static string DecodeMorse(string morseCode)
        {
            return string.Join(" ", morseCode.Split("   ").Select(word => string.Concat(word.Split(" ").Select(MorseCode.Get)))).Trim();
        }
    }

    public static class MorseCode
    {
        public static Dictionary<string, string> morse = new Dictionary<string, string> {
            { ".-", "A" },
            { "-...", "B" },
            { "-.-.", "C" },
            { "-..", "D" },
            { ".", "E" },
            { "..-.", "F" },
            { "--.", "G" },
            { "....", "H" },
            { "..", "I" },
            { ".---", "J" },
            { "-.-", "K" },
            { ".-..", "L" },
            { "--", "M" },
            { "-.", "N" },
            { "---", "O" },
            { ".--.", "P" },
            { "--.-", "Q" },
            { ".-.", "R" },
            { "...", "S" },
            { "-", "T" },
            { "..-", "U" },
            { "...-", "V" },
            { ".--", "W" },
            { "-..-", "X" },
            { "-.--", "Y" },
            { "--..", "Z" },
            { ".----", "1" },
            { "..---", "2" },
            { "...--", "3" },
            { "....-", "4" },
            { ".....", "5" },
            { "-....", "6" },
            { "--...", "7" },
            { "---..", "8" },
            { "----.", "9" },
            { "-----", "0" },
            {"", "" },
            {"#", " " },
            {"...---...", "SOS" },
            {"-.-.--", "!" },
            {".-.-.-", "." }
        };
        public static string Get(this string str)
        {
            return morse[str];
        }
    }
}

