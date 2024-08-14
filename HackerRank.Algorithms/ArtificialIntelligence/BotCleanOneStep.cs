using HackerRank.Algorithms.Common;
using System.Text;

namespace HackerRank.Algorithms.ArtificialIntelligence
{
    public class BotCleanOneStep : BaseSolution, IBaseSolution
    {
        public BotCleanOneStep() : base("https://www.hackerrank.com/challenges/botclean")
        {
                
        }

        const int boardSize = 5;
        int[] pos;
        String[] board;

        public void Execute()
        {
            PrintOutBoard(board);
            next_move(pos[0], pos[1], board);
            PrintOutBoard(board, true);
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

        public void SetExample01()
        {
            pos = new int[2] { 0, 0 };
            board = new String[boardSize] {
                "bd---",
                "-d---",
                "---d-",
                "---d-",
                "--d-d"
            };
        }

        public void SetExample02()
        {
            pos = new int[2] { 0, 0 };
            board = new String[boardSize] {
                "ddddd",
                "d----",
                "d----",
                "d----",
                "d---d"
            };
        }

        public enum Actions
        {
            LEFT, RIGHT, UP, DOWN, CLEAN
        }

        private void next_move(int row, int col, String[] board) 
        {
            var botCoordinates = new Coordinates(row, col);
            if (IsBlockDirty(botCoordinates, board))
            {
                Clean(botCoordinates, board);
            }
            else
            {
                var target = GetClosestDirtyBlockFrom(botCoordinates, board);
                if (target != null)
                {
                    NextStepFromTo(botCoordinates, target, board);
                }
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

        /// <summary>
        /// If we clean is because the Bot is in here, so after we clean the bot will be shown
        /// </summary>
        /// <param name="currentCoordinates"></param>
        /// <param name="board"></param>
        private void Clean(Coordinates currentCoordinates, String[] board)
        {
            Console.WriteLine(Actions.CLEAN.ToString());
            SetBoardCellTo(board, currentCoordinates, 'b');
            PrintOutBoard(board);
        }

        private void SetBoardCellTo(String[] board, Coordinates currentCoordinates, char c) 
        {
            board[currentCoordinates.row] = ReplaceIndexWithChar(board[currentCoordinates.row], currentCoordinates.col, c);
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
                return MoveBotTo(origin, firstDirection, board);
            }
            else
            {
                Console.WriteLine(secondDirection.ToString());
                return MoveBotTo(origin, secondDirection, board);
            }
        }

        private Coordinates MoveBotTo(Coordinates origin, Actions action, String[] board)
        {
            // We calculate without fear that the new coordinates would be valid
            // As long as we know that both origin and target are valid positions
            // In this board all positions are valid, so this will work
            // But if not all positions in the board are valid we need to check
            Coordinates newCoordinates;
            SetBoardCellTo(board, origin, '-');
            switch (action)
            {
                case Actions.LEFT:
                    newCoordinates = new Coordinates(origin.row, origin.col - 1);
                    break;
                case Actions.RIGHT:
                    newCoordinates = new Coordinates(origin.row, origin.col + 1);
                    break;
                case Actions.UP:
                    newCoordinates = new Coordinates(origin.row - 1, origin.col);
                    break;
                case Actions.DOWN:
                    newCoordinates = new Coordinates(origin.row + 1, origin.col);
                    break;
                default:
                    newCoordinates = origin;
                    break;
            }
            if (board[newCoordinates.row][newCoordinates.col] == '-')
            {
                SetBoardCellTo(board, newCoordinates, 'b');
            }
            return newCoordinates;
        }

        private void PrintOutBoard(String[] board, bool overrideDebugMode = false)
        {
            if (!overrideDebugMode && !base.DebugMode) return;

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
