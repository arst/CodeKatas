using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.KarateChop
{
    public class SimpleBinarySearch
    {
        public int Search(int value, int[] input)
        {
            int start = 0;
            int end = input.Length - 1;
            int result = -1;

            while (start <= end) {
                var middle = (start + end) / 2;
                if (value > input[middle])
                {
                    start = middle + 1;
                }
                else if (value < input[middle])
                {
                    end = middle - 1;
                }
                else {
                    return middle;
                }
            }

            return result;
        }
    }
}
