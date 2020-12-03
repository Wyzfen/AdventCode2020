using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day3
    {
        readonly string [] values = Utils.StringsFromFile("day3.txt");
            //new string[]
            //{
            //    "..##.......",
            //    "#...#...#..",
            //    ".#....#..#.",
            //    "..#.#...#.#",
            //    ".#...##..#.",
            //    "..#.##.....",
            //    ".#.#.#....#",
            //    ".#........#",
            //    "#.##...#...",
            //    "#...##....#",
            //    ".#..#...#.#",
            //};

        [TestMethod]
        public void Problem1()
        {
            long result = TestRun(3);

            Assert.AreEqual(result, 276);
        }

        [TestMethod]
        public void Problem2()
        {
            long result = TestRun(1) * TestRun(3) * TestRun(5) * TestRun(7) * TestRun(1, 2);

            Assert.AreEqual(result, 7812180000);
        }

        public long TestRun(int xstep, int ystep = 1)
        {
            long result = 0;
            int x = 0;

            for(int y = 0; y < values.Count(); y += ystep)
            {
                if (values[y][x] == '#') result++;
                x = (x + xstep) % values[y].Length;
            }

            return result;
        }

    }
}
