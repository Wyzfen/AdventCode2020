using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace AdventCode2019
{
    [TestClass]
    public class Day8
    {
        readonly List<(string instr, int value)> values = Utils.StringsFromFile("day8.txt").Select(v => (v.Substring(0, 3),  int.Parse(v.Substring(4)))).ToList(); 

        [TestMethod]
        public void Problem1()
        {
            Execute(values, out int result);

            Assert.AreEqual(result, 1600);
        }

        [TestMethod]
        public void Problem2()
        {
            int result = 0;

            for(int i = 0; i < values.Count; i++)
            {
                (string instr, int value) = values[i];
                if (instr == "acc") continue;

                var copy = new List<(string instr, int value)>(values)
                {
                    [i] = (instr == "jmp" ? "nop" : "jmp", value)
                };

                if (Execute(copy, out result)) break;
            }

            Assert.AreEqual(result, 1543);
        }

        private static bool Execute(List<(string instr, int value)> values, out int acculumator)
        {
            int result = 0;
            var visited = new HashSet<int>();
            int sp = 0;

            do
            {
                (string instr, int value) = values[sp];

                switch (instr)
                {
                    case "acc":
                        result += value;
                        sp++;
                        break;
                    case "jmp":
                        sp += value;
                        break;
                    case "nop":
                        sp++;
                        break;
                }
            } while (visited.Add(sp) && sp < values.Count);

            acculumator = result;

            return sp >= values.Count;
        }
    }
}
