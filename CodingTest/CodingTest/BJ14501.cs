using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ14501
    {
        private int workDay;
        private int[,] works;

        //0 : 사용한 날짜, 1 : 받을수 있는 돈
        private Queue<int[]> queue = new Queue<int[]>();

        public void Solution()
        {
            GetInput();

            int answer = 0;

            for(int i = 0; i < workDay; i++)
            {
                queue.Enqueue(new int[] { i, 0 });

                while(queue.Count != 0)
                {
                    int[] data = queue.Dequeue();
                    int nowDay = data[0];
                    int money = data[1];

                    if (nowDay + 1 > workDay)
                    {
                        answer = (answer < money) ? money : answer;
                    }
                    else
                    {
                        //일을 안하고 넘긴 경우 queue 등록
                        queue.Enqueue(new int[] { nowDay + 1, money });

                        if (works[nowDay, 0] + nowDay <= workDay)
                        {
                            //일을 할 경우 queue 등록
                            queue.Enqueue(new int[] { nowDay + works[nowDay, 0], money + works[nowDay, 1] });
                        }
                    }
                }
            }

            Console.WriteLine(answer);
        }

        private void GetInput()
        {
            workDay = int.Parse(Console.ReadLine());
            works = new int[workDay, 2];

            for (int i = 0; i < workDay; i++)
            {
                string? input = Console.ReadLine();
                string[] split = input.Split();

                works[i,0] = int.Parse(split[0]);
                works[i,1] = int.Parse(split[1]);
            }
        }
    }
}
