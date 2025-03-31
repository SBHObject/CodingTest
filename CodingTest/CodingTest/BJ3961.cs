using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest
{
    internal class BJ3961
    {
        private Dictionary<char, int[]> keyboard = new Dictionary<char, int[]>();

        private int testCase;
        private int caseCount;
        private string input;
        private string[] strings;

        private Dictionary<int, List<string>> output = new Dictionary<int, List<string>>();
        private List<string> list = new List<string>();
        private PriorityQueue<int, int> keys = new PriorityQueue<int, int>();

        public void Solution()
        {
            SetKeyboard();
            testCase = int.Parse(Console.ReadLine());

            for(int i = 0; i < testCase; i++)
            {
                GetInput();

                for(int j = 0; j < strings.Length; j++)
                {
                    int weight = 0;
                    for(int k = 0; k < input.Length; k++)
                    {
                        int[] inputPos = keyboard[input[k]];
                        int[] targetPos = keyboard[strings[j][k]];

                        weight += Math.Abs(inputPos[0] - targetPos[0]) + Math.Abs(inputPos[1] - targetPos[1]);
                    }

                    if (output.ContainsKey(weight))
                    {
                        output[weight].Add(strings[j]);
                        output[weight].Sort((string a, string b) => { return a.CompareTo(b); });
                    }
                    else
                    {
                        output.Add(weight, new List<string>() { strings[j] });
                        keys.Enqueue(weight, weight);
                    }
                }

                while(keys.Count != 0)
                {
                    int key = keys.Dequeue();

                    for(int j = 0; j < output[key].Count; j++)
                    {
                        list.Add($"{output[key][j]} {key}");
                    }
                }

                output.Clear();
            }

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private void GetInput()
        {
            string? firstInput = Console.ReadLine();
            string[] split = firstInput.Split();

            input = split[0];
            caseCount = int.Parse(split[1]);

            strings = new string[caseCount];

            for(int i = 0; i < caseCount; i++)
            {
                strings[i] = Console.ReadLine();
            }
        }

        private void SetKeyboard()
        {
            keyboard.Add('q', new int[] { 0, 0 });
            keyboard.Add('w', new int[] { 1, 0 });
            keyboard.Add('e', new int[] { 2, 0 });
            keyboard.Add('r', new int[] { 3, 0 });
            keyboard.Add('t', new int[] { 4, 0 });
            keyboard.Add('y', new int[] { 5, 0 });
            keyboard.Add('u', new int[] { 6, 0 });
            keyboard.Add('i', new int[] { 7, 0 });
            keyboard.Add('o', new int[] { 8, 0 });
            keyboard.Add('p', new int[] { 9, 0 });
            keyboard.Add('a', new int[] { 0, 1 });
            keyboard.Add('s', new int[] { 1, 1 });
            keyboard.Add('d', new int[] { 2, 1 });
            keyboard.Add('f', new int[] { 3, 1 });
            keyboard.Add('g', new int[] { 4, 1 });
            keyboard.Add('h', new int[] { 5, 1 });
            keyboard.Add('j', new int[] { 6, 1 });
            keyboard.Add('k', new int[] { 7, 1 });
            keyboard.Add('l', new int[] { 8, 1 });
            keyboard.Add('z', new int[] { 0, 2 });
            keyboard.Add('x', new int[] { 1, 2 });
            keyboard.Add('c', new int[] { 2, 2 });
            keyboard.Add('v', new int[] { 3, 2 });
            keyboard.Add('b', new int[] { 4, 2 });
            keyboard.Add('n', new int[] { 5, 2 });
            keyboard.Add('m', new int[] { 6, 2 });
        }
    }
}
