using System;
using CodeWars.App.Challenges;

namespace CodeWars.App
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var x = Intervals.SumIntervals(new[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) });

            Console.ReadKey();
        }
    }
}
