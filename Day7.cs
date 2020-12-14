namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class Day7
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day7.txt.");

            var rules = new Dictionary<string, List<(int, string)>>();

            foreach (string rule in input)
            {
                var words = rule.Split(' ');
                if (words.Contains("other"))
                {
                    continue;
                }
                var container = string.Join(' ', words[0], words[1]);
                var indices = words.Select((_, i) => i).Where(i => int.TryParse(words[i], out int _));
                var contains = new List<(int, string)>();
                foreach (var index in indices)
                {
                    contains.Add((int.Parse(words[index]), string.Join(' ', words[index + 1], words[index + 2])));
                }
                rules.Add(container, contains);
            }
            return recurse("shiny gold", rules);
        }

        private static int recurse(string bag, Dictionary<string, List<(int, string)>> rules)
        {
            if (!rules.ContainsKey(bag))
            {
                return 0;
            }
            var total = 0;
            foreach ((int, string) item in rules[bag])
            {
                total += item.Item1 + (item.Item1 * recurse(item.Item2, rules));
            }
            return total;
        }
    }
}
