// https://www.hackerrank.com/challenges/sock-merchant/problem

// Related solution: https://www.hackerrank.com/challenges/migratory-birds/problem

namespace HackerRank.Algorithms.OldOnes
{
    public static class SalesByMatch
    {

        public static int sockMerchant(int n, List<int> ar)
        {
            // This is a good way to aggregate or count items in an array
            Dictionary<int, int> aggregatedArray = ar
            .GroupBy(item => item)
            .ToDictionary(item => item.Key, item => item.Count());

            // At this point we need to iterate through the dictionary to count the matching pairs
            int pairs = 0;
            foreach (KeyValuePair<int, int> tuple in aggregatedArray)
            {
                pairs = pairs + tuple.Value / 2;
            }

            return pairs;
        }
    }
}
