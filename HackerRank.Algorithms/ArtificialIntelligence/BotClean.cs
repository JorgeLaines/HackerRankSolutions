using HackerRank.Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.ArtificialIntelligence
{
    public class BotClean : BaseSolution, IBaseSolution
    {
        public BotClean() : base("https://www.hackerrank.com/challenges/botclean")
        {
                
        }

        const int boardSize = 5;
        int[] pos;
        String[] board;

        public void Execute()
        {
            PrintOutBoard(board);
            next_move(pos[0], pos[1], board);
        }

        public void Read()
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            pos = new int[2];
            board = new String[boardSize];
            for (int i = 0; i < 5; i++)
            {
                board[i] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
        }

        public void SetDefaultExample() 
        {
            pos = new int[2] { 0, 0 };
            board = new String[boardSize] {
                "b---d",
                "-d--d",
                "--dd-",
                "--d--",
                "----d"
            };
        }

        public enum Actions
        {
            LEFT, RIGHT, UP, DOWN, CLEAN
        }

        private void next_move(int row, int col, String[] board) 
        {
            var botCoordinates = new Coordinates(row, col);
            var target = GetClosestDirtyBlockFrom(botCoordinates, board);
            while(target != null) {
                WalkFromTo(botCoordinates, target, board);
                botCoordinates = target;
                target = GetClosestDirtyBlockFrom(botCoordinates, board);
            }
        }

        private void WalkFromTo(Coordinates origin, Coordinates target, String[] board)
        {
            var currentCoordinates = origin;
            while(!currentCoordinates.Equals(target))
            {
                if (IsBlockDirty(currentCoordinates, board))
                {
                    Clean(currentCoordinates, board);   
                }
                currentCoordinates = NextStepFromTo(currentCoordinates, target, board);
                PrintOutBoard(board);
            }
            if (IsBlockDirty(currentCoordinates, board))
            {
                Clean(currentCoordinates, board);
            }
        }

        private void Clean(Coordinates currentCoordinates, String[] board)
        {
            Console.WriteLine(Actions.CLEAN.ToString());
            board[currentCoordinates.row] = ReplaceIndexWithChar(board[currentCoordinates.row], currentCoordinates.col, '-');
            PrintOutBoard(board);
        }

        private string ReplaceIndexWithChar(string s, int index, char c)
        {
            var newString = new StringBuilder(s);
            newString[index] = c;
            return newString.ToString();
        }

        private Coordinates NextStepFromTo(Coordinates origin, Coordinates target, String[] board)
        {
            var stepsFirstDirection = target.col - origin.col;
            var stepsSecondDirection = target.row - origin.row;

            var firstDirection = stepsFirstDirection > 0 ? Actions.RIGHT : Actions.LEFT;
            var secondDirection = stepsSecondDirection > 0 ? Actions.DOWN : Actions.UP;

            stepsFirstDirection = Math.Abs(stepsFirstDirection);
            stepsSecondDirection = Math.Abs(stepsSecondDirection);

            if (stepsFirstDirection > stepsSecondDirection)
            {
                Console.WriteLine(firstDirection.ToString());
                return MoveTo(origin, firstDirection);
            }
            else
            {
                Console.WriteLine(secondDirection.ToString());
                return MoveTo(origin, secondDirection);
            }
        }

        private Coordinates MoveTo(Coordinates origin, Actions action)
        {
            // We calculate without fear that the new coordinates would be valid
            // As long as we know that both origin and target are valid positions
            // In this board all positions are valid, so this will work
            // But if not all positions in the board are valid we need to check
            switch (action)
            {
                case Actions.LEFT:
                    return new Coordinates(origin.row, origin.col - 1);
                case Actions.RIGHT:
                    return new Coordinates(origin.row, origin.col + 1);
                case Actions.UP:
                    return new Coordinates(origin.row - 1, origin.col);
                case Actions.DOWN:
                    return new Coordinates(origin.row + 1, origin.col);
            }
            return origin;
        }

        private void PrintOutBoard(String[] board)
        {
            Console.WriteLine("=====");
            for (int i = 0; i < boardSize; i++)
            {
                Console.WriteLine(board[i]);
            }
            Console.WriteLine("=====");
        }

        /// <summary>
        /// Dummy search:
        /// From range 1 to 4
        /// Clockwise from (0, 0)
        /// Returns the first ocurrence
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private Coordinates GetClosestDirtyBlockFrom(Coordinates origin, String[] board)
        {
            var maxRange = GetLongestDistanceToBorder(origin);
            for (int range = 1; range < maxRange; range++)
            {
                for (int row = -range; row <= range; row++)
                {
                    for (int col = -range; col <= range; col++)
                    {
                        if(((row == -range || row == range) || 
                            (col == -range || col == range)))
                        {
                            // Console.WriteLine($"range: {range}, row: {origin.row + row}, col: {origin.col + col}");
                            if (IsBlockDirty(new Coordinates(origin.row + row, origin.col + col), board))
                            {
                                return new Coordinates(origin.row + row, origin.col + col);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private int GetLongestDistanceToBorder(Coordinates origin)
        {
            int longestCol = origin.col; 
            int longestRow = origin.row;
            longestCol = boardSize - longestCol > longestCol ? boardSize - longestCol : longestCol;
            longestRow = boardSize - longestRow > longestRow ? boardSize - longestRow : longestRow;
            return longestCol > longestRow ? longestCol : longestRow;
        }

        private bool IsBlockDirty(Coordinates origin, String[] board)
        {
            if ((origin.row >= 0 && origin.row < boardSize) &&
                (origin.col >= 0 && origin.col < boardSize))
            {
                return board[origin.row][origin.col] == 'd';
            }
            return false;
        }
    }
}
