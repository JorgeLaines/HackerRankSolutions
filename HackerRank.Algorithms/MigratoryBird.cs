// https://www.hackerrank.com/challenges/migratory-birds/problem

namespace HackerRank.Algorithms
{
    public static class MigratoryBird
    {
        public static int MigratoryBirds(List<int> arr)
        {
            // Some arrays do not work properly if the array is not previously sorted
            // If this line becomes too heavy to process it can be removed but the process sections needs to be reviewed in order for this to work
            arr.Sort();

            // This is a good way to aggregate or count items in an array
            Dictionary<int, int> aggregatedArray = arr
            .GroupBy(item => item)
            .ToDictionary(item => item.Key, item => item.Count());

            // At this point we need to iterate through the dictionary to get the highest value, this process can be used to find the lowest too
            KeyValuePair<int, int> highestCountTuple = aggregatedArray.First();
            foreach (KeyValuePair<int, int> tuple in aggregatedArray)
            {
                if (tuple.Value > highestCountTuple.Value) highestCountTuple = tuple;
            }

            return highestCountTuple.Key;
        }
    }
}
