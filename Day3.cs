using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day3
    {
        public static long Compute()
        {
            var input = File.ReadAllLines("inputs\\day3.txt");

            var arr = input.Select(x => x.ToCharArray()).ToList();

            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            int tree1 = 0, tree2 = 0, tree3 = 0, tree4 = 0, tree5 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i][x1] == '#')
                {
                    tree1++;
                }
                if (arr[i][x2] == '#')
                {
                    tree2++;
                }
                if (arr[i][x3] == '#')
                {
                    tree3++;
                }
                if (arr[i][x4] == '#')
                {
                    tree4++;
                }

                x1 = (x1 + 1) % arr[0].Length;
                x2 = (x2 + 3) % arr[0].Length;
                x3 = (x3 + 5) % arr[0].Length;
                x4 = (x4 + 7) % arr[0].Length;
            }

            for (int i = 0; i < arr.Count; i+=2)
            {
                if (arr[i][x5] == '#')
                    tree5++;
                x5 = (x5 + 1) % arr[0].Length;
            }
            return tree1 * tree2 * tree3 * tree4 * tree5;
        }
    }
}
