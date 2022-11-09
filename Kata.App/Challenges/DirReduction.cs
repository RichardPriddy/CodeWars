using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.App.Challenges
{
    public class DirReduction
    {

        public static string[] dirReduc(string[] path)
        {
            if (path == null)
                return path;

            var opposites = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
     { "North", "South" },
     { "South", "North" },
     { "East",  "West"  },
     { "West",  "East"  },
   };

            var result = new LinkedList<string>();

            foreach (string direction in path)
                if (!string.Equals(result.Last?.Value,
                                   opposites[direction],
                                   StringComparison.OrdinalIgnoreCase))
                    result.AddLast(direction);
                else
                    result.RemoveLast();

            return result.ToArray();
        }
    }
}
