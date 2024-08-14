namespace HackerRank.Algorithms.OldOnes
{
    public class BonAppetit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill">The list of amount of prices per each dish</param>
        /// <param name="k">The index of the dish that wasn't eat by Anna</param>
        /// <param name="b">The amount of money that Brian assigned Anna</param>
        /// <seealso cref="https://www.hackerrank.com/challenges/bon-appetit/problem"/>
        public static void BonAppetit_v1(List<int> bill, int k, int b)
        {
            var refund = b - (bill.Sum() - bill[k]) / 2;

            Console.WriteLine(refund == 0 ? "Bon Appetit" : refund.ToString());
        }
    }
}
