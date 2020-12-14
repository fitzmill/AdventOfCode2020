namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class Day9
    {
        public static string Compute()
        {
            var input = File.ReadAllLines("inputs\\day9.txt");

            return FindSum(input).ToString();
        }

        private static bool isValid(string[] input, int index)
        {
            for (int i = index-25; i < index-1; i++)
            {
                for (int j = i+1; j < index; j++)
                {
                    if (int.Parse(input[i]) + int.Parse(input[j]) == int.Parse(input[index]))
                        return true;
                }
            }
            return false;
        }

        private static int FindSum(string[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    var list = input.Where((d, ind) => ind >= i && ind <= j).Select(d => int.Parse(d));
                    try
                    {
                        if (list.Sum() > 167829540)
                            break;
                        if (list.Sum() == 167829540)
                        {
                            var max = list.Max();
                            var min = list.Min();
                            return max + min;
                        }
                    }catch (System.OverflowException)
                    {

                    }
                }
            }
            return 0;
        }
    }
}
