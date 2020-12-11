using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode2019
{
    [TestClass]
    public class Day11
    {
        readonly string [] values = Utils.StringsFromFile("day11.txt");

        [TestMethod]
        public void Problem1()
        {
            string[] input = null;
            string[] output = values;

            do
            {
                input = output;
                output = ProcessSeats(input);
            } while (!output.Zip(input, (o, i) => o == i).All(b => b));

            int result = output.Sum(o => o.Count(s => s == '#'));

            Assert.AreEqual(result, 2481);
        }

        [TestMethod]
        public void Problem2()
        {
            string[] input = null;
            string[] output = values;

            do
            {
                input = output;
                output = ProcessSeats2(input);
            } while (!output.Zip(input, (o, i) => o == i).All(b => b));

            int result = output.Sum(o => o.Count(s => s == '#'));

            Assert.AreEqual(result, 2227);
        }

        private string [] ProcessSeats(string [] seats)
        {
            int width = seats[0].Length;
            int height = seats.Length;

            string[] output = new string[height];
            
            for(int y = 0; y < height; y++)
            {
                var irow = seats[y];
                var orow = new StringBuilder(irow);

                for(int x = 0; x < width; x++)
                {
                    int count = 0;

                    if (x > 0 && y > 0 && seats[y - 1][x - 1] == '#') count++;
                    if (x > 0 && seats[y][x - 1] == '#') count++;
                    if (x > 0 && y < height - 1 && seats[y + 1][x - 1] == '#') count++;
                    if (x < width - 1 && y > 0 && seats[y - 1][x + 1] == '#') count++;
                    if (x < width - 1 && seats[y][x + 1] == '#') count++;
                    if (x < width - 1 && y < height - 1 && seats[y + 1][x + 1] == '#') count++;
                    if (y > 0 && seats[y - 1][x] == '#') count++;
                    if (y < height - 1 && seats[y + 1][x] == '#') count++;

                    if (count == 0 && irow[x] == 'L') orow[x] = '#';
                    if (count >= 4 && irow[x] == '#') orow[x] = 'L';
                }

                output[y] = orow.ToString();
            }

            return output;
        }

        private string[] ProcessSeats2(string[] seats)
        {
            int width = seats[0].Length;
            int height = seats.Length;

            string[] output = new string[height];

            for (int y = 0; y < height; y++)
            {
                var irow = seats[y];
                var orow = new StringBuilder(irow);

                for (int x = 0; x < width; x++)
                {
                    int count = 0;

                    if (IsOccupied(seats, x, y, width, height, -1, -1)) count++;
                    if (IsOccupied(seats, x, y, width, height, -1,  0)) count++;
                    if (IsOccupied(seats, x, y, width, height, -1,  1)) count++;
                    if (IsOccupied(seats, x, y, width, height,  0, -1)) count++;
                    if (IsOccupied(seats, x, y, width, height,  0,  1)) count++;
                    if (IsOccupied(seats, x, y, width, height,  1, -1)) count++;
                    if (IsOccupied(seats, x, y, width, height,  1,  0)) count++;
                    if (IsOccupied(seats, x, y, width, height,  1,  1)) count++;

                    if (count == 0 && irow[x] == 'L') orow[x] = '#';
                    if (count >= 5 && irow[x] == '#') orow[x] = 'L';
                }

                output[y] = orow.ToString();
            }

            return output;
        }

        private bool IsOccupied(string [] input, int x, int y, int width, int height, int deltaX, int deltaY)
        {
            while(x + deltaX >= 0 && x + deltaX < width && y + deltaY >= 0 && y + deltaY < height)
            {
                x += deltaX;
                y += deltaY;

                char value = input[y][x];
                if (value == '#') return true;
                if (value == 'L') return false;
            }

            return false;
        }
    }
}
