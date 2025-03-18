using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ2564
    {
        private int width;
        private int height;

        private int shopCount;
        private int[,] shops;
        private int[] position = new int[2];

        public void Solution()
        {
            GetInput();

            int length = 0;

            for (int i = 0; i < shopCount; i++)
            {
                int xGap = Math.Abs(position[0] - shops[i, 0]);
                int yGap = Math.Abs(position[1] - shops[i, 1]);
                int additinal = 0;

                if(yGap == height)
                {
                    int a = (position[0] < width - position[0]) ? position[0] : width - position[0];
                    int b = (shops[i, 0] < width - shops[i, 0]) ? shops[i, 0] : width - shops[i, 0];
                    additinal = (a < b) ? a : b;
                }

                if(xGap == width)
                {
                    int c = (position[1] < height - position[1]) ? position[1] : height - position[1];
                    int d = (shops[i, 1] < height - shops[i, 1]) ? shops[i, 1] : height - shops[i, 1];
                    additinal = (c < d) ? c : d;
                }

                length += xGap + yGap + additinal * 2;
            }

            Console.WriteLine(length);
        }

        private void GetInput()
        {
            string? firstLine = Console.ReadLine();

            var firstLineSplit = firstLine.Split();

            width = int.Parse(firstLineSplit[0]);
            height = int.Parse(firstLineSplit[1]);

            shopCount = int.Parse(Console.ReadLine());
            shops = new int[shopCount, 2];

            for (int i = 0; i < shopCount; i++)
            {
                string? lines = Console.ReadLine();
                var split = lines.Split();

                int[] newPos = ToCoordinate(int.Parse(split[0]), int.Parse(split[1]));

                //1:북, 2:남, 3:서, 4:동
                shops[i, 0] = newPos[0];
                shops[i, 1] = newPos[1];
            }

            string positionInput = Console.ReadLine();
            var positionSplit = positionInput.Split();

            position = ToCoordinate(int.Parse(positionSplit[0]), int.Parse(positionSplit[1]));
        }

        private int[] ToCoordinate(int index, int amount)
        {
            switch (index)
            {
                case 1:
                    return new int[] { amount, 0 };
                case 2:
                    return new int[] { amount, height };
                case 3:
                    return new int[] { 0, amount };
                case 4:
                    return new int[] { width, amount };
                default:
                    return new int[] { 0, 0 };
            }
        }
    }
}
