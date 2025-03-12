using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class BJ1654
    {
        uint heldLine;
        uint needLine;

        uint[] lines;

        public void Solution()
        {
            GetInput();

            uint answer = 0;
            uint end = uint.MinValue;

            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i] > end)
                {
                    end = lines[i];
                }
            }

            uint start = 1;

            while (start <= end)
            {
                uint count = 0;
                uint mid = (start + end) / 2;

                for (int i = 0; i < lines.Length; i++)
                {
                    count += lines[i] / mid;
                }

                if(count >= needLine)
                {
                    start = mid + 1;
                    answer = mid;
                }
                else
                {
                    end = mid - 1;
                }
            }

            Console.WriteLine(answer);
        }

        private void GetInput()
        {
            var firstLine = Console.ReadLine();

            string[] split = firstLine.Split();

            heldLine = uint.Parse(split[0]);
            needLine = uint.Parse(split[1]);

            lines = new uint[heldLine];

            for(int i = 0; i < heldLine; i ++)
            {
                var input = Console.ReadLine();

                lines[i] = uint.Parse(input);
            }
        }
    }
}
