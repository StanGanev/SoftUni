using System;
using System.Linq;

namespace _02_Rainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var initValue = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                initValue[i] = nums[i];
            }
            var initIndex = nums[nums.Count - 1];
            nums.RemoveAt(nums.Count - 1);
            var donaldSteps = initIndex;

            for (int count = 0; count <= nums.Count; count++)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i]--;
                }

                if (nums[donaldSteps] == 0)
                {
                    Console.WriteLine(string.Join(" ", nums));
                    Console.WriteLine(count);
                    return;
                }

                if (nums.Contains(0))
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] == 0)
                        {
                            nums[i] = initValue[i];
                        }
                    }
                }

                donaldSteps = int.Parse(Console.ReadLine());
            }
        }
    }
}
