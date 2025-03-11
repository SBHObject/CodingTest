using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ17070
    {
        private int[] rightPos = { 0, 1 };
        //0 : 가로, 1 : 대각선, 2 : 세로
        private int pipe = 0;

        private int answer = 0;

        private int[,] house;

        private int target;

        private Stack<int[]> route = new Stack<int[]>();

        public void Solution()
        {
            SetInput();

            route.Push(new int[] { pipe, rightPos[0], rightPos[1] });

            while(route.Count != 0)
            {
                int[] pop = route.Pop();
                pipe = pop[0];
                rightPos[0] = pop[1];
                rightPos[1] = pop[2];

                if (rightPos[0] == target && rightPos[1] == target)
                {
                    answer++;
                    continue;
                }

                switch(pipe)
                {
                    case 0:
                        if(MoveRight())
                        {
                            route.Push(new int[] { 0, rightPos[0], rightPos[1] + 1 });
                        }

                        if(MoveDiagonal())
                        {
                            route.Push(new int[] { 1, rightPos[0] + 1, rightPos[1] + 1 });
                        }
                        break;

                    case 1:
                        if(MoveRight())
                        {
                            route.Push(new int[] { 0, rightPos[0], rightPos[1] + 1 });
                        }

                        if(MoveDiagonal())
                        {
                            route.Push(new int[] { 1, rightPos[0] + 1, rightPos[1] + 1 });
                        }

                        if(MoveDown())
                        {
                            route.Push(new int[] { 2, rightPos[0] + 1, rightPos[1] });
                        }
                        break;

                    case 2:
                        if (MoveDiagonal())
                        {
                            route.Push(new int[] { 1, rightPos[0] + 1, rightPos[1] + 1 });
                        }

                        if (MoveDown())
                        {
                            route.Push(new int[] { 2, rightPos[0] + 1, rightPos[1] });
                        }
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(answer);
        }

        private void SetInput()
        {
            var input = Console.ReadLine();
            int.TryParse(input, out int size);

            target = size - 1;
            house = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                var houseInput = Console.ReadLine();
                string[] split = houseInput.Split();

                for (int j = 0; j < size; j++)
                {
                    house[i, j] = int.Parse(split[j]);
                }
            }
        }

        private bool MoveRight()
        {
            if (rightPos[1] >= target)
                return false;

            if (house[rightPos[0], rightPos[1] + 1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MoveDown()
        {
            if (rightPos[0] >= target)
                return false;

            if (house[rightPos[0] + 1, rightPos[1]] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MoveDiagonal()
        {
            if (rightPos[0] >= target || rightPos[1] >= target)
                return false;

            if (MoveDown() && MoveRight() && house[rightPos[0] + 1, rightPos[1] + 1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
