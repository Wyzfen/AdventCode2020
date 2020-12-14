using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day13
    {
        readonly string [] values = Utils.StringsFromFile("day13.txt");

        [TestMethod]
        public void Problem1()
        {
            int time = int.Parse(values[0]);
            int [] busses = values[1].Split(',').Select(v => int.TryParse(v, out int r) ? r : 0).Where(v => v > 0).ToArray();
            
            int id = busses[0];
            int min = int.MaxValue;

            for (int i = 0; i < busses.Length; i++)
            {
                int rem = busses[i] - time % busses[i];

                if(rem < min)
                {
                    min = rem;
                    id = busses[i];
                }
            }

            int result = min * id;
            Assert.AreEqual(result, 4782);
        }

        [TestMethod]
        public void Problem2()
        {
            var busses = values[1].Split(',').Select((v, i) => (value: int.TryParse(v, out int r) ? r : 0, index: i)).Where(p => p.value != 0).ToDictionary(p => p.value, p => p.index);

            // 19a + 13 = 37b   ->  11 + 37n, 6 + 19n
            // 19a + 19 = 883c  ->  -1 + 883n', 0 + 19n'
            // => 11 + 37x = -1 + 883y -> 12 = 883y - 37x -> 119 + 883n, 5 + 37n


            long result = 0;

            Assert.AreEqual(result, 80072256);
        }
    }
}
