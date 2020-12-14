namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class Day10
    {
        public static long Compute()
        {
            var input = File.ReadAllLines("inputs\\day10.txt");

            var cast = input.Select(i => int.Parse(i));
            var destination = cast.Max();
            var stack = new Stack<long>();
            stack.Push(0);
            var dataStore = new Dictionary<long, long>();

            /*
             * So essentially what I'm doing here is a depth first search, but I'm only counting a node as
             * "processed" (numbers in the datastore are considered processed) when all of a node's neighbours
             * have been processed. Also, this implements a flavor of the A* algorithm, where I process the numbers
             * closest to the destination first. Otherwise, things get wacky when the stack is out of order.
             * 
             */
            while (stack.Count > 0)
            {
                var currentNum = stack.Pop();
                var neighbors = cast.Where((c) => c > currentNum && c <= currentNum + 3).OrderBy(i => i); //neighbors with the highest numbers end up being the first processed
                var readdedToStack = false;
                long paths = 0;
                foreach (var n in neighbors)
                {
                    if (n == destination)
                        paths++;
                    else if (!dataStore.ContainsKey(n))
                    {
                        if (!readdedToStack)
                        {
                            //if any of the node's neighbors haven't been processed, we have to come back later to get the total number of paths
                            stack.Push(currentNum);
                            readdedToStack = true;
                        }
                        stack.Push(n);
                    }
                    else
                    {
                        paths += dataStore[n];
                    }
                }
                //only add to the datastore if all neighbors have been processed
                if (paths > 0 && !readdedToStack)
                    dataStore.Add(currentNum, paths);
            }
            return dataStore.GetValueOrDefault(0);
        }
    }
}
