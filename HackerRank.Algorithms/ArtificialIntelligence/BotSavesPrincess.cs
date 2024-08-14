using HackerRank.Algorithms.Common;

namespace HackerRank.Algorithms.ArtificialIntelligence
{
    public class BotSavesPrincess : BaseSolution, IBaseSolution
    {
        internal int m;
        internal String[] grid;

        public BotSavesPrincess() : base("https://www.hackerrank.com/challenges/saveprincess")
        {
            
        }

        public void Execute()
        {
            displayPathtoPrincess(m, grid);
        }

        public void Read()
        {
            m = int.Parse(Console.ReadLine());
            grid = new String[m];
            for (int i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }
        }

        public void SetDefaultExample()
        {

        }

        internal enum direction 
        {
            LEFT,
            RIGHT, 
            UP,
            DOWN
        }

        void displayPathtoPrincess(int m, String[] grid) {
            Coordinates botCoordinates = FindCharacterInGrid('m');
            Coordinates princessCoordinates = FindCharacterInGrid('p');

            var stepsFirstDirection = princessCoordinates.col - botCoordinates.col;
            var stepsSecondDirection = princessCoordinates.row - botCoordinates.row;

            var firstDirection = stepsFirstDirection > 0 ? direction.RIGHT : direction.LEFT;
            var secondDirection = stepsSecondDirection > 0 ? direction.DOWN : direction.UP;

            stepsFirstDirection = Math.Abs(stepsFirstDirection);
            stepsSecondDirection = Math.Abs(stepsSecondDirection);

            while (stepsFirstDirection + stepsSecondDirection > 0) 
            {
                if (stepsFirstDirection > 0)
                {
                    Console.WriteLine(firstDirection.ToString());
                    stepsFirstDirection--;
                }
                if (stepsSecondDirection > 0)
                {
                    Console.WriteLine(secondDirection.ToString());
                    stepsSecondDirection--;
                }
            }

        }

        int FromGridCoordinatesToStringIndex(Coordinates coord)
        {
            if ((coord.row < 0 && coord.row >= m) || (coord.col < 0 && coord.col >= m)) throw new ArgumentException("Index out of range!");
            return coord.row * m + coord.col;
        }

        Coordinates FromStringIndexToGridCoordinates(int index)
        {
            if (index < 0 && index >= m*m) throw new ArgumentException("Index out of range!");
            return new Coordinates(index / m, index % m);
        }

        Coordinates FindCharacterInGrid(char character)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < m; i++)
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
