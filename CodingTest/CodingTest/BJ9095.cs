using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ9095
    {
        private int count;
        private int[] numbers;

        public void Solution()
        {
            GetInput();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(GetAnswer(numbers[i]));
            }
        }

        public void GetInput()
        {
            count = int.Parse(Console.ReadLine());
            
            numbers = new int[count];
            for(int i = 0; i < count; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
        }

        public int GetAnswer(int targetNum)
        {
            //DP 는 원래 이런가;;
            //1 -> 1
            //2-> 2
            //3-> 4
            //4-> 7
            //5-> 13
            //6-> 24
            //7-> 44
            if (targetNum <= 1)
            {
                return 1;
            }
            else if(targetNum == 2)
            {
                return 2;
            }

            int num1 = GetAnswer(targetNum - 1);
            int num2 = GetAnswer(targetNum - 2);
            int num3 = GetAnswer(targetNum - 3);

            int answerNum = num1 + num2 + num3;

            return answerNum;
        }
    }
}
