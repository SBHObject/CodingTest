using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ12865
    {
        private int stuffCount;
        private int possibleWeight;

        // 0 : 무게, 1 : 가치
        private int[,] stuffs;

        private int[,] pack;

        public void Solution()
        {
            GetInput();

            for(int i = 0; i <= stuffCount; i++)
            {
                int weight = 0;
                int worth = 0;

                if (i != 0)
                {
                    weight = stuffs[i - 1, 0];
                    worth = stuffs[i - 1, 1];
                }

                for(int j = 0; j <= possibleWeight; j++)
                {
                    if(j == 0 || i == 0)
                    {
                        pack[i, j] = 0;
                    }
                    else
                    {
                        if(weight > j)
                        {
                            pack[i, j] = pack[i - 1, j];
                        }
                        else
                        {
                            pack[i, j] = (pack[i - 1, j - weight] + worth < pack[i - 1, j]) ? pack[i - 1, j] : pack[i - 1, j - weight] + worth;
                        }
                    }
                }
            }

            Console.WriteLine(pack[stuffCount, possibleWeight]);
        }

        private void GetInput()
        {
            string? input = Console.ReadLine();
            string[] split = input.Split();

            stuffCount = int.Parse(split[0]);
            possibleWeight = int.Parse(split[1]);

            stuffs = new int[stuffCount, 2];
            pack = new int[stuffCount + 1, possibleWeight + 1];

            for (int i = 0; i < stuffCount; i++)
            {
                string? stuffInput = Console.ReadLine();
                string[] stuffSplit = stuffInput.Split();

                stuffs[i, 0] = int.Parse(stuffSplit[0]);
                stuffs[i, 1] = int.Parse(stuffSplit[1]);
            }
        }
    }
}
