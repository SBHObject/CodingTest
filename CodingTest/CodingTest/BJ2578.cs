using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ2578
    {
        private int[,,] bingoBoard = new int[5,5,2];
        private Queue<int> number = new Queue<int>();

        public void Solution()
        {
            GetInput();

            int bingoCount = 0;
            int callCount = 0;

            while(bingoCount < 3)
            {
                callCount++;

                int call = number.Dequeue();
                int[] position = new int[2];

                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        if (bingoBoard[i,j,0] == call)
                        {
                            position[0] = i;
                            position[1] = j;
                            bingoBoard[i, j, 1] = 1;
                        }
                    }
                }

                if(CheckRank(position))
                {
                    bingoCount++;
                }

                if(CheckStripe(position))
                {
                    bingoCount++;
                }

                if(CheckSlash(position))
                {
                    bingoCount++;
                }

                if(CheckBackSlash(position))
                {
                    bingoCount++;
                }
            }

            Console.WriteLine(callCount);
        }

        private bool CheckRank(int[] pos)
        {
            int x = pos[0];
            int y = pos[1];

            int add = 0;

            int check = 0;

            while (check != 4)
            {
                add++;

                if (x + add < 5)
                {
                    if(bingoBoard[x + add, y, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }

                if (x - add >= 0)
                {
                    if (bingoBoard[x - add, y, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }
            }

            return true;
        }

        private bool CheckStripe(int[] pos)
        {
            int x = pos[0];
            int y = pos[1];

            int add = 0;

            int check = 0;

            while (check != 4)
            {
                add++;

                if (y + add < 5)
                {
                    if (bingoBoard[x, y + add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }

                if (y - add >= 0)
                {
                    if (bingoBoard[x, y - add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }
            }

            return true;
        }

        private bool CheckSlash(int[] pos)
        {
            int x = pos[0];
            int y = pos[1];

            if(x + y != 4)
            {
                return false;
            }

            int add = 0;

            int check = 0;

            while (check != 4)
            {
                add++;

                if (x + add < 5 && y - add < 5)
                {
                    if (bingoBoard[x + add, y - add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }

                if (x - add >= 0 && y + add >= 0)
                {
                    if (bingoBoard[x - add, y + add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }
            }

            return true;
        }

        private bool CheckBackSlash(int[] pos)
        {
            int x = pos[0];
            int y = pos[1];

            if (x - y != 0)
            {
                return false;
            }

            int add = 0;

            int check = 0;

            while (check != 4)
            {
                add++;

                if (x + add < 5 && y + add < 5)
                {
                    if (bingoBoard[x + add, y + add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }

                if (x - add >= 0 && y - add >= 0)
                {
                    if (bingoBoard[x - add, y - add, 1] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        check++;
                    }
                }
            }

            return true;
        }


        private void GetInput()
        {
            for (int i = 0; i < 5; i++)
            {
                string? line = Console.ReadLine();
                string[] lineSplit = line.Split();

                for (int j = 0; j < lineSplit.Length; j++)
                {
                    int bingoNum = int.Parse(lineSplit[j]);

                    bingoBoard[i,j,0] = bingoNum;
                    bingoBoard[i, j, 1] = 0;
                }
            }

            for(int k = 0; k < 5; k++)
            {
                string? callLine = Console.ReadLine();
                string[] callSplit = callLine.Split();

                foreach(string c in callSplit)
                {
                    number.Enqueue(int.Parse(c));
                }
            }

        }
    }
}
