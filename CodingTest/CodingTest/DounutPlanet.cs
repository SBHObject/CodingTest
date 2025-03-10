using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class DounutPlanet
    {
        public int[,]? area;
        private Queue<int[]> nodeQueue = new Queue<int[]>();

        int nLength;
        int mLength;

        public void Solution()
        {
            GetLine();
        }

        private void GetLine()
        {
            Console.SetCursorPosition(0, 0);

            string getLine = Console.ReadLine();
            string[] splitString = getLine.Split();

            int n = int.Parse(splitString[0]);
            int m = int.Parse(splitString[1]);

            area = new int[n, m];

            nLength = n;
            mLength = m;

            ExplorationArea(n , m);
        }

        private void ExplorationArea(int n, int m)
        {
            int answer = 0;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] split = line.Split();

                for(int j = 0; j < m; j++)
                {
                    area[i, j] = int.Parse(split[j]);
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (area[i,j] == 0)
                    {
                        answer++;
                        CheckVisite(i, j);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(answer);
        }

        private void CheckVisite(int n ,int m)
        {
            if (n + 1 >= nLength)
            {
                if (area?[0, m] == 0)
                {
                    int[] num = { 0, m };
                    nodeQueue.Enqueue(num);
                    area[0, m] = 1;
                }
            }
            else
            {
                if (area?[n + 1, m] == 0)
                {
                    int[] num = { n + 1, m };
                    nodeQueue.Enqueue(num);
                    area[n + 1, m] = 1;
                }
            }

            if (m + 1 >= mLength)
            {
                if (area[n, 0] == 0)
                {
                    int[] num = { n, 0 };
                    nodeQueue.Enqueue(num);
                    area[n, 0] = 1;
                }
            }
            else
            {
                if (area[n, m + 1] == 0)
                {
                    int[] num = { n, m + 1 };
                    nodeQueue.Enqueue(num);
                    area[n, m + 1] = 1;
                }
            }

            if (n - 1 < 0)
            {
                if (area[nLength - 1, m] == 0)
                {
                    int[] num = { nLength - 1, m };
                    nodeQueue.Enqueue(num);
                    area[nLength - 1, m] = 1;
                }
            }
            else
            {
                if (area[n - 1, m] == 0)
                {
                    int[] num = { n - 1, m };
                    nodeQueue.Enqueue(num);
                    area[n - 1, m] = 1;
                }
            }

            if (m - 1 < 0)
            {
                if (area[n, mLength - 1] == 0)
                {
                    int[] num = { n, mLength - 1 };
                    nodeQueue.Enqueue(num);
                    area[n, mLength - 1] = 1;
                }
            }
            else
            {
                if (area[n, m - 1] == 0)
                {
                    int[] num = { n, m - 1};
                    nodeQueue.Enqueue(num);
                    area[n, m - 1] = 1;
                }
            }

            if(nodeQueue.Count != 0)
            {
                int[] num = nodeQueue.Dequeue();

                CheckVisite(num[0], num[1]);
            }
        }
    }
}
