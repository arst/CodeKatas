using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.KarateChop
{
    public class FunctionalBinarySearch
    {
        public int Search(int value, int[] input)
        {
            return SearchInternal(value, input, 0, input.Length - 1);
        }

        private int SearchInternal(int value, int[] input, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            if(start == end)
            {
                return input[start] == value ? start : -1;
            }
            var mid = (start + start + end) / 2;
            switch (mid)
            {
                case var i when input[i] == value:
                    return mid;
                case var i when input[i] > value:
                    return SearchInternal(value, input, start, mid - 1);
                case var i when input[i] < value:
                    return SearchInternal(value, input, mid + 1, end);
                default:
                    return -1;
            }
        }
    }
}
