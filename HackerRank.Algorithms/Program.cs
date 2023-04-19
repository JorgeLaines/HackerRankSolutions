namespace HackerRank.Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(DayOfProgrammer.DayOfProgrammer_v1(1800));

            var cube = new List<List<int>>() {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };

            Console.WriteLine(MagicSquare.formingMagicSquare(cube));

            Console.ReadLine();
        }
    }
}