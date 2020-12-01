using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day1
    {
        readonly IEnumerable<int> values = Utils.IntsFromFile("day1.txt");

        [TestMethod]
        public void Problem1()
        {
            int result = Utils.Combinations(values, 2).First(v => v.Sum() == 2020).Aggregate((a,b) => a * b);

            Assert.AreEqual(result, 485739);
        }

        [TestMethod]
        public void Problem2()
        {
            int result = Utils.Combinations(values, 3).First(v => v.Sum() == 2020).Aggregate((a, b) => a * b);

            Assert.AreEqual(result, 161109702);
        }
    }
}
