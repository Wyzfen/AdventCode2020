using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day5
    {
        readonly int [] values = Utils.StringsFromFile("day5.txt").Select(a => Convert.ToInt32(a.Replace('B', '1').Replace('F', '0').Replace('R', '1').Replace('L', '0'), 2)).ToArray();

        [TestMethod]
        public void Problem1()
        {
            int result = values.Max();

            Assert.AreEqual(result, 935);
        }

        [TestMethod]
        public void Problem2()
        {
            int min = values.Min();
            int max = values.Max();

            int result = Enumerable.Range(min, max - min + 1).Except(values).First();

            Assert.AreEqual(result, 743);
        }
    }
}
