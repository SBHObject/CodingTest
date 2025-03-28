using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ14503
    {
        private int[,] map;
        private int width;
        private int height;

        private int[] startPos = new int[2];
        //0 : 북, 1 : 동, 2 : 남, 3 : 서
        private int look;

        private int[,] quarter = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        public void Solution()
        {
            GetInput();

            int answer = 0;
            int[] currentPos = startPos;
            int currentLook = look;

            while (true)
            {
                bool canMove = false;
                bool nonClean = false;

                if(map[currentPos[0], currentPos[1]] == 0)
                {
                    answer++;

                    map[currentPos[0], currentPos[1]] = 2;
                }

                for(int i = 0; i < 4; i++)
                {
                    if (map[currentPos[0] + quarter[i, 0], currentPos[1] + quarter[i, 1]] == 0)
                    {
                        nonClean = true;
                        break;
                    }
                }

                if (nonClean)
                {
                    while (!canMove)
                    {
                        currentLook = (currentLook - 1 < 0) ? 3 : currentLook - 1;

                        if (map[currentPos[0] + quarter[currentLook, 0], currentPos[1] + quarter[currentLook, 1]] == 0)
                        {
                            currentPos[0] += quarter[currentLook, 0];
                            currentPos[1] += quarter[currentLook, 1];
                            canMove = true;
                        }
                    }
                }
                else
                {
                    int back = (currentLook - 2 < 0) ? currentLook + 2 : currentLook - 2;

                    if (map[currentPos[0] + quarter[back ,0], currentPos[1] + quarter[back , 1]] != 1)
                    {
                        currentPos[0] += quarter[back, 0];
                        currentPos[1] += quarter[back, 1];
                        canMove = true;
                    }
                }

                if(canMove == false)
                {
                    break;
                }
            }

            Console.WriteLine(answer);
        }

        private void GetInput()
        {
            string? mapInput = Console.ReadLine();
            string[] mapSplit = mapInput.Split();

            height = int.Parse(mapSplit[0]);
            width = int.Parse(mapSplit[1]);

            map = new int[height, width];

            string? cleanerInput = Console.ReadLine();
            string[] cleanerSplit = cleanerInput.Split();

            startPos[0] = int.Parse(cleanerSplit[0]);
            startPos[1] = int.Parse(cleanerSplit[1]);
            look = int.Parse(cleanerSplit[2]);

            for (int i = 0; i < height; i++)
            {
                string? input = Console.ReadLine();
                string[] split = input.Split();

                for (int j = 0; j < width; j++)
                {
                    map[i, j] = int.Parse(split[j]);
                }
            }
        }
    }
}
