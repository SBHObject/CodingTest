using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ2023
    {
        private int number;

        private Queue<int> specialPrimeNums = new Queue<int>();

        public void Solution()
        {
            GetInput();

            for(int i = 2; i < 10; i ++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                {
                    specialPrimeNums.Enqueue(i);
                }
            }

            int target = (int)Math.Pow(10, number - 1);

            while (specialPrimeNums.Peek() < target)
            {
                int multiply10 = specialPrimeNums.Dequeue() * 10;
                
                for (int i = 0; i < 10; i++)
                {
                    int checkNum = multiply10 + i;
                    bool isPrime = true;
                    int forTarget = (int)Math.Sqrt(checkNum) + 1;

                    for(int j = 2; j < forTarget; j++)
                    {
                        if(checkNum % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if(isPrime)
                    {
                        specialPrimeNums.Enqueue(checkNum);
                    }
                }
            }

            int output = specialPrimeNums.Count;
            for (int i = 0; i < output; i++)
            {
                Console.WriteLine(specialPrimeNums.Dequeue());
            }
        }

        private void GetInput()
        {
            var input = Console.ReadLine();

            number = int.Parse(input);
        }
    }
}
