using System.Linq;

namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Day6
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day6.txt");

            var count = 0;
            var people = 0;
            var tracker = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    count += tracker.Values.Count(v => v == people);
                    people = 0;
                    tracker = new Dictionary<char, int>();
                    continue;
                }
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (tracker.ContainsKey(input[i][j]))
                        tracker[input[i][j]]++;
                    else
                        tracker.Add(input[i][j], 1);
                }
                people++;
            }
            return count + tracker.Values.Count(v => v == people);
        }
    }
}
