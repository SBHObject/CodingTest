using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ5719
    {
        private int nodeCount;
        private int routeCount;

        private int start;
        private int end;

        // [i,0] : 노드, [i,1] : 이동 가능 노드, [i,2] : 가중치
        private int[,] routes;
        // [i, 0] : 거리, [i, 1] : 방문 여부
        private int[,] minDistances;
        private int[,] shortestRoute;

        private PriorityQueue<int[], int> priQueue = new PriorityQueue<int[], int>();
        private Queue<int> answerQueue = new Queue<int>();

        public void Solution()
        {
            while(GetInput())
            {
                priQueue.Enqueue(new int[] { start, 0 }, 0);
                
                while(priQueue.Count != 0)
                {
                    var data = priQueue.Dequeue();

                    if (minDistances[data[0], 1] == 0)
                    {
                        minDistances[data[0], 1] = 1;
                    }
                    else
                    {
                        continue;
                    }

                    for (int i = 0; i < routeCount; i++)
                    {
                        if (data[0] == routes[i, 0])
                        {
                            int curWeight = routes[i, 2] + data[1];

                            if (minDistances[routes[i, 1], 0] > curWeight)
                            {
                                priQueue.Enqueue(new int[] { routes[i, 1], curWeight }, curWeight);
                                minDistances[routes[i, 1], 0] = curWeight;
                            }
                        }
                    }
                }

                for(int j = 0; j < routeCount; j++)
                {

                }

                answerQueue.Enqueue(minDistances[end, 0]);
            }

            while(answerQueue.Count != 0)
            {
                Console.WriteLine(answerQueue.Dequeue());
            }
        }

        private bool GetInput()
        {
            string? nodeAndRoute = Console.ReadLine();
            string[] split = nodeAndRoute.Split();

            nodeCount = int.Parse(split[0]);
            routeCount = int.Parse(split[1]);

            if(nodeCount == 0 && routeCount == 0)
            {
                return false;
            }

            string? startAndEnd = Console.ReadLine();
            split = startAndEnd.Split();

            start = int.Parse(split[0]);
            end = int.Parse(split[1]);

            routes = new int[routeCount, 3];
            minDistances = new int[nodeCount, 2];
            shortestRoute = new int[nodeCount, nodeCount];

            for(int i = 0; i < routeCount; i++)
            {
                string? routeInput = Console.ReadLine();
                string[] inputSplit = routeInput.Split();

                routes[i, 0] = int.Parse(inputSplit[0]);
                routes[i, 1] = int.Parse(inputSplit[1]);
                routes[i, 2] = int.Parse(inputSplit[2]);
            }

            for(int j = 0; j < nodeCount; j++)
            {
                minDistances[j, 0] = int.MaxValue;
                minDistances[j, 1] = 0;
            }

            return true;
        }
    }
}
