using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ1194
    {
        private int row;
        private int colume;

        private char[,] map;
        private int[,,] visited;

        private Queue<int[]> route = new Queue<int[]>(1<<18);
        private int[,] moveset = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        private int[] startPos = new int[2];

        public void Solution()
        {
            GetInput();

            int minMove = int.MaxValue;
            bool isFinish = false;

            // x위치, y위치, 이동횟수, 키
            route.Enqueue(new int[4] { startPos[0], startPos[1], 0, 0 });

            while(route.Count > 0)
            {
                int[] dequeue = route.Dequeue();
                int[] nowPosition = { dequeue[0], dequeue[1] };
                int moveCount = dequeue[2] + 1;
                int keyinfo = dequeue[3];

                if(moveCount > minMove)
                {
                    continue;
                }

                for(int i = 0; i < 4; i++)
                {
                    int newX = nowPosition[0] + moveset[i, 0];
                    int newY = nowPosition[1] + moveset[i, 1];

                    if(newX >= 0 && newX < row && newY >= 0 && newY < colume)
                    {
                        if (visited[newX, newY, keyinfo] > 0)
                        {
                            continue;
                        }

                        char positionInfo = map[newX, newY];

                        switch (positionInfo)
                        {
                            case '.': case '0':
                                route.Enqueue(new int[] { newX, newY, moveCount, keyinfo });
                                visited[newX, newY, keyinfo] = 1;
                                break;

                            case '1':
                                isFinish = true;

                                minMove = (minMove < moveCount)? minMove : moveCount;
                                break;

                            case 'a': case 'b': case 'c': case 'd': case 'e': case 'f':
                                int powNum = positionInfo - 'a';
                                int newKey = keyinfo | (1 << powNum);
                                
                                route.Enqueue(new int[] { newX, newY, moveCount, newKey });
                                visited[newX, newY, newKey] = 1;
                                break;

                            case 'A': case 'B': case 'C': case 'D': case 'E': case 'F':
                                int powLargeNum = positionInfo - 'A';
                                int checkNum = keyinfo & (1 << powLargeNum);

                                if(checkNum != 0)
                                {
                                    route.Enqueue(new int[] { newX, newY, moveCount, keyinfo });
                                    visited[newX, newY, keyinfo] = 1;
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            if (isFinish)
            {
                Console.WriteLine(minMove);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private void GetInput()
        {
            string? sizeInput = Console.ReadLine();
            string[] splitSize = sizeInput.Split();

            row = int.Parse(splitSize[0]);
            colume = int.Parse(splitSize[1]);

            map = new char[row, colume];
            visited = new int[row, colume, 1<<6];

            for(int i = 0; i < row; i++)
            {
                string? rowInput = Console.ReadLine();

                for(int j = 0; j < colume; j++)
                {
                    map[i, j] = rowInput[j];
                    if (rowInput[j] == '0')
                    {
                        startPos[0] = i;
                        startPos[1] = j;
                    }
                }
            }
        }
    }
}
