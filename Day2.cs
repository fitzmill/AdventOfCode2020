using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day2
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day2.txt");

            var numValid = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var parts = line.Split(' ');
                var numbers = parts[0].Split('-');
                var letter = parts[1].Substring(0, 1);
                var pwd = parts[2];

                int.TryParse(numbers[0], out int low);
                int.TryParse(numbers[1], out int high);
                if (pwd.Substring(low-1, 1) == letter || pwd.Substring(high-1, 1) == letter)
                {
                    if (!(pwd.Substring(low - 1, 1) == letter && pwd.Substring(high - 1, 1) == letter))
                        numValid++;
                }
            }

            return numValid;
        }
    }
}
