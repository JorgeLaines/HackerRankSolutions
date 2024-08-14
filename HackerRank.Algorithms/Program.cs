using HackerRank.Algorithms.ArtificialIntelligence;

namespace HackerRank.Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new BotCleanOneStep();
            solution.DebugMode = true;
            solution.SetExample02();
            solution.Execute();
            Console.ReadLine();
        }
    }
}