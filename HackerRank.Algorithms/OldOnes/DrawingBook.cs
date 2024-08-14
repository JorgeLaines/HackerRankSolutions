// https://www.hackerrank.com/challenges/drawing-book/problem

namespace HackerRank.Algorithms.OldOnes
{
    public static class DrawingBook
    {
        public static int pageCount(int n, int p)
        {
            var targetPageGroup = (p - p % 2) / 2 + 1;
            var endPageGroup = (n - n % 2) / 2 + 1;
            var minPageTurnFromBeginning = targetPageGroup - 1;
            var minPageTurnFromEnd = endPageGroup - targetPageGroup;
            if (minPageTurnFromBeginning < minPageTurnFromEnd) return minPageTurnFromBeginning;
            return minPageTurnFromEnd;
        }
    }
}
