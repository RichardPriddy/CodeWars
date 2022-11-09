namespace CodeWars.App.Challenges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SG1
    {
        public class DHD
        {
            private Coordinates currentPosition;
            public char[][] Crystals { get; set; }
            public Coordinates Start { get; private set; }
            public Coordinates End { get; private set; }

            public int PathwayLength { get; set; }
            public bool IsInWorkingCondition { get; set; }
            public bool Unsolvable { get; set; }

            public DHD(string input)
            {
                var lines = input.Split("\n");
                Crystals = lines.Select(i => i.ToCharArray()).ToArray();

                Start = FindCoordinatesOf('S');
                End = FindCoordinatesOf('G');
                currentPosition = Start;

                PathwayLength = 0;
                IsInWorkingCondition = End.IsAdjcentTo(Start);
                Unsolvable = false;
            }

            /// <summary>
            /// Increments the path length by the cost of the next step
            /// updates the current position
            /// Sets the next pathway step to P
            /// Determines if the DHD is now in working condition
            /// </summary>
            /// <param name="coordinates">The next pathway step to make</param>
            public void SetPathway(Coordinates coordinates)
            {
                PathwayLength += PathCost(coordinates);
                currentPosition = coordinates;
                Crystals[coordinates.Y][coordinates.X] = 'P';
                IsInWorkingCondition = End.IsAdjcentTo(coordinates);
            }

            /// <summary>
            /// Calculates the cost of the pathway based on the direction of the path.
            /// </summary>
            /// <param name="coordinates">The next step in the pathway</param>
            /// <returns></returns>
            private int PathCost(Coordinates coordinates)
            {
                if(coordinates.X == currentPosition.X)
                    return 1;
                if (coordinates.Y == currentPosition.Y)
                    return 2;
                return 3;
            }

            /// <summary>
            /// Looks for all available pathways from the current position
            /// figures out if theis particular DHD pathway is solvable
            /// </summary>
            /// <returns>Returns a new DHD for each possible pathway.</returns>
            public List<DHD> Step()
            {
                var availablePositions = AvailableCoordinates(currentPosition);
                if(availablePositions.Length == 0)
                {
                    Unsolvable = true;
                    return new List<DHD>();
                }

                return availablePositions.Select(p =>
                {
                    var dhd = new DHD(this.ToString());
                    dhd.SetPathway(p);
                    return dhd;
                }).ToList();
            }

            public override string ToString()
            {
                return string.Join('\n', Crystals.Select(i => string.Join("", i)));
            }

            /// <summary>
            /// Look through all the crystals and find the requested item
            /// Used to find the start and end crystals.
            /// </summary>
            /// <param name="find">The character to look for</param>
            /// <returns>The coordinates of the requested crystal</returns>
            private Coordinates FindCoordinatesOf(char find)
            {
                var coords = new Coordinates(0, 0);
                foreach (var line in Crystals)
                {
                    var sIndex = Array.IndexOf(line, find);
                    if (sIndex >= 0)
                    {
                        coords.X = sIndex;
                        break;
                    }
                    coords.Y++;
                }
                return coords;
            }

            /// <summary>
            /// Figure out all possible directions the pathway could take.
            /// </summary>
            /// <param name="position">Starting position to look for availbe positions from</param>
            /// <returns>All available positions</returns>
            private Coordinates[] AvailableCoordinates(Coordinates position)
            {
                var leftX = Math.Max(position.X - 1, 0);
                var rightX = Math.Min(position.X + 1, Crystals[0].Length - 1);

                var topY = Math.Max(position.Y - 1, 0);
                var bottomY = Math.Min(position.Y + 1, Crystals.Length - 1);

                var available = new List<Coordinates>();

                for (int y = bottomY; y >= topY; y--)
                {
                    for (int x = rightX; x >= leftX; x--)
                    {
                        if (Crystals[y][x] == '.')
                        {
                            available.Add(new Coordinates(x, y));
                        }
                    }
                }

                return available.ToArray();
            }

        }

        public class Coordinates
        {
            public Coordinates(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;

            /// <summary>
            /// Determines if the provided coordinate is adjcent to this one.
            /// </summary>
            /// <param name="compare"></param>
            /// <returns>True if adjcent</returns>
            public bool IsAdjcentTo(Coordinates compare)
            {
                var X = compare.X >= this.X - 1 && compare.X <= this.X + 1;
                var Y = compare.Y >= this.Y - 1 && compare.Y <= this.Y + 1;

                if (X && Y)
                {
                    return true;
                }

                return false;

            }

            /// <summary>
            /// Are the X and Y coordinates of the provided object equal to those of this one
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if(obj is Coordinates)
                {
                    var coord = obj as Coordinates;

                    return (coord.X == X && coord.Y == Y);
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }

        public static string WireDHD(string existingWires)
        {
            var dhd = new DHD(existingWires);
            var dhds = new List<DHD> { dhd };

            var currentPosition = dhd.Start;

            var n = 0;
            do
            {
                var solved = dhds.Where(d => !d.Unsolvable).OrderBy(d=> d.PathwayLength).FirstOrDefault(d => d.IsInWorkingCondition);
                if (solved != null) { return solved.ToString(); }

                if(!dhds.Any())
                {
                    return "Oh for crying out loud...";
                }

                dhds = dhds.SelectMany(d => d.Step()).ToList();
                n++;
            } while (n < 50);

            throw new Exception(existingWires);
        }
    }
}
