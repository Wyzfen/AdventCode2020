using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace AdventCode2019
{
    [TestClass]
    public class Day2
    {
        readonly IEnumerable<string> values = Utils.StringsFromFile("day2.txt"); // <min>-<max> <letter>: <pw>

        [TestMethod]
        public void Problem1()
        {
            int result = 0;

            foreach(var line in values)
            {
                var splits = line.Split('-', ' ', ':');
                var (min, max, letter, password) = (int.Parse(splits[0]), int.Parse(splits[1]), splits[2][0], splits[4]);

                int count = password.Count(c => c == letter);

                if (count >= min && count <= max) result++;               
            }

            Assert.AreEqual(result, 465);
        }

        [TestMethod]
        public void Problem2()
        {
            int result = 0;

            foreach (var line in values)
            {
                var splits = line.Split('-', ' ', ':');
                var (first, second, letter, password) = (int.Parse(splits[0]), int.Parse(splits[1]), splits[2][0], splits[4]);

                char firstIndex = password[first - 1];
                char secondIndex = password[second - 1];

                if ((firstIndex == letter || secondIndex == letter) && firstIndex != secondIndex) result++;
            }

            Assert.AreEqual(result, 294);
        }
    }
}
