using HackerRank.Algorithms.Common;

namespace HackerRank.Algorithms.ArtificialIntelligence
{
    public class BotSavesPrincess2 : BaseSolution, IBaseSolution
    {
        internal int n;
        internal int[] int_pos;
        internal String[] grid;

        public BotSavesPrincess2() : base("https://www.hackerrank.com/challenges/saveprincess2")
        {
            
        }

        public void Execute()
        {
            nextMove(n, int_pos[0], int_pos[1], grid);
        }

        public void Read()
        {
            n = int.Parse(Console.ReadLine());
            String pos;
            pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int_pos = new int[2];
            int_pos[0] = Convert.ToInt32(position[0]);
            int_pos[1] = Convert.ToInt32(position[1]);
            grid = new String[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }
        }

        internal enum direction 
        {
            LEFT,
            RIGHT, 
            UP,
            DOWN
        }

        void nextMove(int n, int r, int c, String[] grid) {
            var botCoordinates = new Coordinates(r, c);
            Coordinates princessCoordinates = FindCharacterInGrid('p', n, grid);

            var stepsFirstDirection = princessCoordinates.col - botCoordinates.col;
            var stepsSecondDirection = princessCoordinates.row - botCoordinates.row;

            var firstDirection = stepsFirstDirection > 0 ? direction.RIGHT : direction.LEFT;
            var secondDirection = stepsSecondDirection > 0 ? direction.DOWN : direction.UP;

            stepsFirstDirection = Math.Abs(stepsFirstDirection);
            stepsSecondDirection = Math.Abs(stepsSecondDirection);

            if (stepsFirstDirection > stepsSecondDirection)
            {
                Console.WriteLine(firstDirection.ToString());
            }
            else
            {
                Console.WriteLine(secondDirection.ToString());
            }
        }

        Coordinates FindCharacterInGrid(char character, int n, String[] grid)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < n; i++)
            {
                col = grid[i].IndexOf(character);
                if (col >= 0)
                {
                    row = i; break;
                }
            }
            return new Coordinates(row, col);
        }
    }
}
