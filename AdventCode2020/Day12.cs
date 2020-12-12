using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day12
    {
        readonly string [] values = Utils.StringsFromFile("day12.txt");

        [TestMethod]
        public void Problem1()
        {
            int result = FollowProgram(values);

            Assert.AreEqual(result, 923);
        }

        [TestMethod]
        public void Problem2()
        {
            long result = FollowProgram2(values);

            Assert.AreEqual(result, 24769);
        }

        private int FollowProgram(string [] input)
        {
            int x = 0;
            int y = 0;
            int bearing = 0;

            foreach(var s in input)
            {
                int distance = int.Parse(s.Substring(1));
                switch(s[0])
                {
                    case 'N':
                        y-= distance;
                        break;
                    case 'S':
                        y+=distance;
                        break;
                    case 'E':
                        x+=distance;
                        break;
                    case 'W':
                        x-=distance;
                        break;
                    case 'L':
                        bearing = (bearing - distance / 90 + 4) % 4;                        
                        break;
                    case 'R':
                        bearing = (bearing + distance / 90) % 4;
                        break;
                    case 'F':
                        switch(bearing)
                        {
                            case 0: // E
                                x += distance;
                                break;
                            case 1: // S
                                y += distance;
                                break;
                            case 2: // W
                                x -= distance;
                                break;
                            case 3: // N
                                y -= distance;
                                break;
                        }
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        private long FollowProgram2(string[] input)
        {
            long x = 0;
            long y = 0;

            long wx = 10;
            long wy = 1;
            
            foreach (var s in input)
            {
                int distance = int.Parse(s.Substring(1));
                switch (s[0])
                {
                    case 'N':
                        wy += distance;
                        break;
                    case 'S':
                        wy -= distance;
                        break;
                    case 'E':
                        wx += distance;
                        break;
                    case 'W':
                        wx -= distance;
                        break;
                    case 'L':
                        for(int l = 0; l < distance / 90; l++)
                        {
                            long t = wx;
                            wx = -wy;
                            wy = t;
                        }                        
                        break;
                    case 'R':
                        for (int r = 0; r < distance / 90; r++)
                        {
                            long t = -wx;
                            wx = wy;
                            wy = t;
                        }
                        break;
                    case 'F':
                        x += wx * distance;
                        y += wy * distance;
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
