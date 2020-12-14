namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Day5
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day5.txt");

            int highest = 0;
            var cache = new bool[128*8];

            for (int i = 0; i < input.Length; i++)
            {
                double low = 0, high = 127;
                for (int j = 0; j < 7; j++)
                {
                    if (input[i][j] == 'F')
                        high = Math.Floor((low+high) / 2);
                    else
                        low = Math.Ceiling((low+high) / 2);
                }
                int row = Convert.ToInt32(low);

                low = 0; high = 7;
                for (int j = 7; j < 10; j++)
                {
                    if (input[i][j] == 'L')
                        high = Math.Floor((low+high) / 2);
                    else
                        low = Math.Ceiling((low + high) / 2);
                }
                int col = Convert.ToInt32(low);
                var id = (row * 8) + col;
                cache[id] = true;
                if (id > highest)
                {
                    highest = id;
                }
            }
            while (cache[highest] == true && highest > 0)
                highest--;
            return highest;
        }
    }
}
