using static System.Math;

namespace HackerRank.Algorithms.OldOnes
{
    public static class MagicSquare
    {
        public static int formingMagicSquare(List<List<int>> s)
        {
            var sums = SumingUp(s);
            var estimateTargetSum = (int)Round(sums.Average(), 0);
            var deviations = sums.Select(s => s - estimateTargetSum).ToArray();
            // If we want to achieve the least changes we need to start on the biggest differences
            // If we resolve those first the minor differences might be resolved once we go


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
