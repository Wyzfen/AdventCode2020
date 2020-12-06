using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day4
    {
        readonly List<List<string>> values = Utils.MergeLines(/**/Utils.StringsFromFile("day4.txt")
                                    /*/new string[] {
                                        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd        ",
                                        "byr:1937 iyr:2017 cid:147 hgt:183cm               ",
                                        "                                                  ",
                                        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884   ",
                                        "hcl:#cfa07d byr:1929                              ",
                                        "                                                  ",
                                        "hcl:#ae17e1 iyr:2013                              ",
                                        "eyr:2024                                          ",
                                        "ecl:brn pid:760753108 byr:1931                    ",
                                        "hgt:179cm                                         ",
                                        "                                                  ",
                                        "hcl:#cfa07d eyr:2025 pid:166559648                ",
                                        "iyr:2011 ecl:brn hgt:59in                         "
                                    }/**/).Select(v => String.Join(" ", v).Split(' ').ToList()).ToList(); // Join groups of lines into one set

        [TestMethod]
        public void Problem1()
        {
            int result = values.Count(i => i.Count == 8 || (i.Count == 7 && !i.Any(s => s.Contains("cid"))));

            Assert.AreEqual(result, 208);
        }

        [TestMethod]
        public void Problem2()
        {
            List<Dictionary<string, string>> inputs = values.Select(v => v.ToDictionary(i => i.Substring(0, 3), i => i.Substring(4))).ToList();
            int result = inputs.Count(i => ValidatePassport(i));            

            Assert.AreEqual(result, 167);
        }

        private static bool ValidatePassport(Dictionary<string, string> passport)
        {
            if (passport.Count < 7) return false;

            Func<string, int, int, bool> testValue = (string input, int min, int max) => int.TryParse(input, out int value) && value >= min && value <= max;
            string[] eyes = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            int validCount = 0;
            foreach(var kvp in passport)
            {
                string value = kvp.Value;
                switch (kvp.Key)
                {
                    case "byr":
                        if (testValue(value, 1920, 2002)) validCount++;
                        break;
                    case "iyr":
                        if (testValue(value, 2010, 2020)) validCount++;
                        break;
                    case "eyr":
                        if (testValue(value, 2020, 2030)) validCount++;
                        break;
                    case "hgt":
                        switch(value.Substring(value.Length - 2))
                        {
                            case "cm":
                                if (testValue(value.Substring(0, value.Length - 2), 150, 193)) validCount++;
                                break;
                            case "in":
                                if (testValue(value.Substring(0, value.Length - 2), 59, 76)) validCount++;
                                break;
                            default:
                                return false;
                        }
                        break;
                    case "hcl":
                        if (value[0] == '#' && value.Substring(1).All(c => "0123456789abcdef".Contains(c))) validCount++;
                        break;
                    case "ecl":
                        if (eyes.Contains(value)) validCount++;
                        break;
                    case "pid":
                        if (value.Length == 9 && long.TryParse(value, out long r)) validCount++;
                        break;
                    case "cid": // Ignored
                        break;
                    default:
                        return false;
                }
            }

            return validCount >= 7;
        }
    }
}
