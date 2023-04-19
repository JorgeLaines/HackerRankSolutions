using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public static class MagicSquare
    {
        public static int formingMagicSquare(List<List<int>> s)
        {
            var sums = SumingUp(s);
            return 0;
        }

        private static int[] SumingUp(List<List<int>> s)
        {
            var sums = new int[6];
            sums[0] = s[0][0] + s[0][1] + s[0][2];
            sums[1] = s[1][0] + s[1][1] + s[1][2];
            sums[2] = s[2][0] + s[2][1] + s[2][2];
            sums[3] = s[0][0] + s[1][0] + s[2][0];
            sums[4] = s[0][1] + s[1][1] + s[2][1];
            sums[5] = s[0][2] + s[1][2] + s[2][2];
            return sums;
        }


    }
}
