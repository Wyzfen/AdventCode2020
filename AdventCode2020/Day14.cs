using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day14
    {
        readonly string[] values = Utils.StringsFromFile("day14.txt");
             //new string[] { "mask = 000000000000000000000000000000X1001X",
             //               "mem[42] = 100",
             //               "mask = 00000000000000000000000000000000X0XX",
             //               "mem[26] = 1"};

        [TestMethod]
        public void Problem1()
        {
            Dictionary<int, long> memory = new Dictionary<int, long>();
            Regex regex = new Regex("mem\\[(\\d+)\\] = (\\d+)");

            long maskOR = 0L;
            long maskAND = ~0L;

            foreach (string line in values)
            {
                if (line.StartsWith("mask"))
                {
                    var sub = line.Substring(7);
                    maskAND = Convert.ToInt64(sub.Replace('X', '1'), 2);
                    maskOR  =  Convert.ToInt64(sub.Replace('X', '0'), 2);
                }
                else
                {
                    var match = regex.Match(line);
                    int index = int.Parse(match.Groups[1].ToString());
                    long value = long.Parse(match.Groups[2].ToString());
                    value &= maskAND;
                    value |= maskOR;
                    memory[index] = value;
                }
            }

            long result = memory.Values.Sum();
            
            Assert.AreEqual(result, 12610010960049);
        }

        [TestMethod]
        public void Problem2()
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();
            Regex regex = new Regex("mem\\[(\\d+)\\] = (\\d+)");

            long maskOR = 0L;
            long maskMSK = ~0L;
            long [] maskFLT = null;

            foreach (string line in values)
            {
                if (line.StartsWith("mask"))
                {
                    var sub = line.Substring(7);
                    maskMSK = Convert.ToInt64(sub.Replace('0', '1').Replace('X', '0'), 2);
                    maskFLT = sub.Select((c, i) => c == 'X' ?  1L << (sub.Length - 1 - i) : 0).Where(v => v > 0).ToArray();
                    maskOR = Convert.ToInt64(sub.Replace('X', '0'), 2);
                }
                else
                {
                    var match = regex.Match(line);
                    long index = int.Parse(match.Groups[1].ToString());
                    long value = long.Parse(match.Groups[2].ToString());
                    index |= maskOR;

                    memory[index & maskMSK] = value; // Handle 0 case

                    for (int i = 1; i <= maskFLT.Length; i++)
                    {
                        var combinations = Utils.Combinations(maskFLT, i);
                        foreach (var combination in combinations)
                        {
                            var mask = combination.Sum();

                            index &= maskMSK;
                            index |= mask;

                            memory[index] = value;
                        }
                    }
                }
            }

            long result = memory.Values.Sum();

            Assert.AreEqual(result, 3608464522781);
        }
    }
}
