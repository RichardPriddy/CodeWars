using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Interval = System.ValueTuple<int, int>;

namespace CodeWars.App.Challenges
{
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            static (int, int)[] dedupe((int, int)[] input)
            {
                var deduped = new List<(int, int)>();
                var overlaps = false;

                for (int i = 0; i < input.Length; i++)
                {
                    // Not last element in the array and the next element starts before this one ends?
                    if (i + 1 < input.Length && input[i].Item2 > input[i + 1].Item1)
                    {
                        // Deduplicate this entry by using element's start and the max of this element, or the next
                        // Max is used in case the next element ends before the current one as well. (next interval fits inside this one?)
                        deduped.Add(new Interval(input[i].Item1, Math.Max(input[i].Item2, input[i + 1].Item2)));
                        overlaps = true;
                        // Skip over the next index as we've merged it into this one
                        i++;
                    }
                    else
                    {
                        // If there isn't an overlap for this entry, just add it to the dedupe list
                        deduped.Add(input[i]);
                    }
                }

                // If there are no overlaps we can just return the list, otherwise, we must run it through dedupe again.
                if (!overlaps) return input;
                else return dedupe(deduped.ToArray());
            }

            return dedupe(intervals.OrderBy(i => i.Item1).ToArray()).Select(i => i.Item2 - i.Item1).Sum(i => i);
        }
    }
}
