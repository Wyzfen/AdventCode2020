using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day6
    {
        readonly List<List<string>> values = Utils.MergeLines(Utils.StringsFromFile("day6.txt"));

        [TestMethod]
        public void Problem1()
        {
            int result = values.Sum(v => string.Concat(v).Distinct().Count());

            Assert.AreEqual(result, 6911);
        }

        [TestMethod]
        public void Problem2()
        {
            int result = values.Sum(v => v.Aggregate((a, b) => String.Concat(a.Intersect(b))).Count());

            Assert.AreEqual(result, 3473);
        }
    }
}
