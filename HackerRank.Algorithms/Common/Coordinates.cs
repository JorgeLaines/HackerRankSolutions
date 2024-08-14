namespace HackerRank.Algorithms.Common
{
    public class Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int row { get; set; }
        public int col { get; set; }

        public bool Equals(Coordinates target)
        { 
            return this.row == target.row && this.col == target.col;
        }
    }
}
