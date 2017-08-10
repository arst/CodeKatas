using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.KarateChop
{
    public class RecursiveBinarySearch
    {
        public int Search(int value, int[] input)
        {
            return SearchRecursive(value, input, 0, input.Length - 1);
        }

        private int SearchRecursive(int value, int[] input, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            if (start == end)
            {
                return input[start] == value ? start : -1;
            }
        
            var mid = (start + start + end) / 2;
            if (value == input[mid])
            {
                return mid;
            }
            else if (value < input[mid])
            {
                return SearchRecursive(value, input, start, mid - 1);
            }
            else {
                return SearchRecursive(value, input, mid + 1, end);
            }
        }
    }
}
