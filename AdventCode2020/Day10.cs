using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day10
    {
        readonly IEnumerable<int> values = Utils.IntsFromFile("day10.txt").OrderBy(v => v);

        [TestMethod]
        public void Problem1()
        {
            int [] deltas = values.Zip(values.Skip(1), (a, b) => b - a).ToArray();
            int ones = deltas.Count(v => v == 1) + (values.First() == 1 ? 1 : 0);
            int result = ones * (deltas.Length - ones + 2);

            Assert.AreEqual(result, 2590);
        }

        [TestMethod]
        public void Problem2()
        {
            var v = values.ToList();
            v.Insert(0, 0);
            v.Add(v.Last() + 3);

            var count = v.ToDictionary(i => i, _ => (long) 0);
            count[0] = 1;

            for(int i = 1; i < v.Count; i++)
            {
                long sum = 0;
                int value = v[i];
                for(int j = Math.Max(0, i - 3); j < i; j++)
                {
                    if (value - v[j] <= 3) sum += count[v[j]];
                }

                count[value] = sum;
            }

            long result = count[v.Last()];

            Assert.AreEqual(result, 226775649501184);
        }
    }
}
