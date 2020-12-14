namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class Day8
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day8.txt");
            int accumulator;
            string[] inputCopy = new string[input.Length];
            input.CopyTo(inputCopy, 0);
            var testChangeIndex = 0;
            var numFailed = 0;
            while (!TestRun(inputCopy, out accumulator))
            {
                testChangeIndex++;
                Console.WriteLine("Failure" + numFailed++);
                input.CopyTo(inputCopy, 0);
                while (!inputCopy[testChangeIndex].StartsWith("nop") && !inputCopy[testChangeIndex].StartsWith("jmp"))
                    testChangeIndex++;
                if (inputCopy[testChangeIndex].StartsWith("nop"))
                    inputCopy[testChangeIndex] = inputCopy[testChangeIndex].Replace("nop", "jmp");
                else
                    inputCopy[testChangeIndex] = inputCopy[testChangeIndex].Replace("jmp", "nop");
            }
            return accumulator;
        }

        private static bool TestRun(string[] input, out int accumulator)
        {
            var executedInstructions = new HashSet<int>();
            var nextInstruction = 0;
            accumulator = 0;
            while (!executedInstructions.Contains(nextInstruction))
            {
                executedInstructions.Add(nextInstruction);
                var inst = input[nextInstruction];
                if (inst.StartsWith("nop"))
                {
                    nextInstruction += 1;
                }
                else if (inst.StartsWith("acc"))
                {
                    if (inst.Contains('+'))
                    {
                        accumulator += int.Parse(inst[(inst.IndexOf('+') + 1)..]);
                    }
                    else
                    {
                        accumulator -= int.Parse(inst[(inst.IndexOf('-') + 1)..]);
                    }
                    nextInstruction++;
                }
                else
                {
                    if (inst.Contains('+'))
                    {
                        nextInstruction += int.Parse(inst[(inst.IndexOf('+') + 1)..]);
                    }
                    else
                    {
                        nextInstruction -= int.Parse(inst[(inst.IndexOf('-') + 1)..]);
                    }
                }
                if (nextInstruction == input.Length)
                    return true;
            }
            return false;
        }
    }
}
