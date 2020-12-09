using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day9
    {
        readonly long [] values = Utils.LongsFromFile("day9.txt").ToArray();

        [TestMethod]
        public void Problem1()
        {
            long result = 0;
            for (int i = 0; i < values.Length + 25; i++)
            {
                result = values[i + 25];
                if(!Utils.Combinations(values.Skip(i).Take(25), 2).Any(v => v[0] + v[1] == result))
                {
                    break;
                }
            }

            Assert.AreEqual(result, 1492208709);
        }

        [TestMethod]
        public void Problem2()
        {
            long result = 0;
            
            for(int i = 0; i < values.Length; i++)
            {
                int j = i;
                long value = values[i];
                long sum = value;
                long min = value;
                long max = value;

                do
                {
                    j++;
                    value = values[j];
                    min = Math.Min(min, value);
                    max = Math.Max(max, value);
                    sum += value;
                } while (sum < 1492208709);

                if(sum == 1492208709)
                {
                    result = min + max;
                    break;
                }
            }

            Assert.AreEqual(result, 238243506);
        }
    }
}
