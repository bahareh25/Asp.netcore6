using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static  class Solution1
    {
        public static int RemoveElement(int[] nums, int val)
        {
            StringBuilder s = new StringBuilder();
            int count = 0;
            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] == val)
                {
                    s.Append("-");
                    count++;
                }

                else
                    s.Append(nums[i].ToString());

                s.Append(",");
            }
            System.Console.WriteLine($"output:{0},nums=[{1}]", count.ToString(), s);
            return 0;
        }
    }
}
