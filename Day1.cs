using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day1
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day1.txt");
            for (int i = 0; i < input.Length-2; i++)
            {
                int.TryParse(input[i], out int a);
                for (int j = i+1; j < input.Length-1; j++)
                {
                    int.TryParse(input[j], out int b);

                    for (int k = j+1; k < input.Length; k++)
                    {
                        int.TryParse(input[k], out int c);

                        if (a + b + c == 2020)
                        {
                            return a * b * c;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
