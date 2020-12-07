using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventCode2019
{
    [TestClass]
    public class Day7
    {
        readonly IEnumerable<string> input = Utils.StringsFromFile("day7.txt"); // (<color>) bags contain( no other bags.)|( <n> <color> bags][,.])*
        [TestMethod]
        public void Problem1()
        {
            Func<string, List<string>> GetBags = (string bag) => input.Where(v => v.Contains(bag))
                                                                    .Select(v => v.Substring(0, v.IndexOf(" bags contain")))
                                                                    .Where(v => v != bag)
                                                                    .ToList();

            
            HashSet<string> bags = new HashSet<string>(new string[] { "shiny gold" });

            for (int i = 0; i < bags.Count; i++)
            {
                string bag = bags.ElementAt(i);                
                var newBags = GetBags(bag);

                newBags.ForEach(n => bags.Add(n));                        
            }

            int result = bags.Count() - 1;


            Assert.AreEqual(result, 177);
        }

        [TestMethod]
        public void Problem2()
        {
            var bags = new Dictionary<string, Dictionary<string, int>>();

            foreach(var row in input)
            {
                var key = row.Substring(0, row.IndexOf(" bags contain"));
                var values = row.Substring(key.Length + 13, row.Length - key.Length - 14);
                var dict = values.Split(',').Where(v => v != " no other bags").ToDictionary(v => v.Substring(3, v.Length - 7).TrimEnd(), v => v[1] - '0');
                bags[key] = dict;
            }
            
            int result = RecurseBags(bags, "shiny gold") - 1;

            Assert.AreEqual(result, 34988);
        }

        private int RecurseBags(Dictionary<string, Dictionary<string, int>> bags, string bag)
        {
            return 1 + bags[bag].Sum(v => v.Value * RecurseBags(bags, v.Key));
        }
    }
}
